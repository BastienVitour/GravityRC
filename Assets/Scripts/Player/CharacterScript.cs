using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Collider2D myCollider;
    public Direction direction;
    public Vector3 gameObjectPosition;
    private Camera mainCamera;
    public Vector2 spawn = new Vector2(0,0);
    private bool canChangeGravity = false;
    public Animator animator;
    public float gravityScale = 15;
    private AudioSource gravityInversionSound;
    private AudioSource landingSound;

    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.DOWN;
        mainCamera = Camera.main;
        AudioSource[] sources = GetComponents<AudioSource>();
        gravityInversionSound = sources[0];
        landingSound = sources[1];
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canChangeGravity) {
            ChangeGravity();
        }

        switch (direction)
        {
            case Direction.UP:
                Physics2D.gravity = new Vector2(0, gravityScale);
                break;
            case Direction.DOWN:
                Physics2D.gravity = new Vector2(0, -gravityScale);
                break;
            case Direction.LEFT:
                Physics2D.gravity = new Vector2(-gravityScale, 0);
                break;
            case Direction.RIGHT:
                Physics2D.gravity = new Vector2(gravityScale, 0);
                break;
            default:
                Physics2D.gravity = new Vector2(0, -gravityScale);
                break;
        }

        gameObjectPosition = gameObject.transform.position;
        mainCamera.transform.position = new Vector3(gameObjectPosition.x, gameObjectPosition.y, -10);
        
        if(Input.GetKeyUp(KeyCode.Escape)) {
            SceneManager.LoadScene("HomeScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 playerPosition = gameObject.transform.position;
        Vector2 contactPoint = other.GetContact(0).point;
        switch (direction)
        {
            case Direction.UP:
                if(contactPoint.y > playerPosition.y) {
                    landingSound.Play();
                    animator.SetTrigger("Landing");
                    StartCoroutine(mainCamera.GetComponent<CameraShakeScript>().Shaking());
                    animator.SetBool("Falling", false);
                    canChangeGravity = true;
                }
                break;
            case Direction.DOWN:
                if(contactPoint.y < playerPosition.y) {
                    landingSound.Play();
                    animator.SetTrigger("Landing");
                    StartCoroutine(mainCamera.GetComponent<CameraShakeScript>().Shaking());
                    animator.SetBool("Falling", false);
                    canChangeGravity = true;
                }
                break;
            case Direction.LEFT:
                if(contactPoint.x < playerPosition.x) {
                    landingSound.Play();
                    animator.SetTrigger("Landing");
                    StartCoroutine(mainCamera.GetComponent<CameraShakeScript>().Shaking());
                    animator.SetBool("Falling", false);
                    canChangeGravity = true;
                }
                break;
            case Direction.RIGHT:
                if(contactPoint.x > playerPosition.x) {
                    landingSound.Play();
                    animator.SetTrigger("Landing");
                    StartCoroutine(mainCamera.GetComponent<CameraShakeScript>().Shaking());
                    animator.SetBool("Falling", false);
                    canChangeGravity = true;
                }
                break;
            default:
                canChangeGravity = false;
                break;
        }
    }

    public void Kys() {
        animator.SetTrigger("Death");

        StartCoroutine(DelayDeath(animator.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator DelayDeath(float delay = 0)
    {
        yield return new WaitForSeconds(0.75f);
        transform.position = spawn;
        direction = Direction.DOWN;
        transform.rotation = Quaternion.identity;
        transform.rotation *= Quaternion.Euler(0, 0, 0);
        myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    public void NextLevel(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    private void ChangeGravity()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow) && direction != Direction.UP) {
            gravityInversionSound.Play();
            direction = Direction.UP;
            transform.rotation = Quaternion.identity;
            transform.rotation *= Quaternion.Euler(0, 0, 180);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            canChangeGravity = false;
            animator.SetBool("Falling", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) && direction != Direction.LEFT) {
            gravityInversionSound.Play();
            direction = Direction.LEFT;
            transform.rotation = Quaternion.identity;
            transform.rotation *= Quaternion.Euler(0, 0, -90);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            canChangeGravity = false;
            animator.SetBool("Falling", true);
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow) && direction != Direction.RIGHT) {
            gravityInversionSound.Play();
            direction = Direction.RIGHT;
            transform.rotation = Quaternion.identity;
            transform.rotation *= Quaternion.Euler(0, 0, 90);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            canChangeGravity = false;
            animator.SetBool("Falling", true);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow) && direction != Direction.DOWN) {
            gravityInversionSound.Play();
            direction = Direction.DOWN;
            transform.rotation = Quaternion.identity;
            transform.rotation *= Quaternion.Euler(0, 0, 0);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            canChangeGravity = false;
            animator.SetBool("Falling", true);
        }
    }
}

public enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT
}
 