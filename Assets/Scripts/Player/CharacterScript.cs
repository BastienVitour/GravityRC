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
    public int playerSpeed = 500;
    private bool canChangeGravity = false;
    public SpriteRenderer mySpriteRenderer;
    public Sprite landingSprite;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.DOWN;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(canChangeGravity) {
            if(Input.GetKeyUp(KeyCode.UpArrow)) {
                direction = Direction.UP;
                transform.rotation = Quaternion.identity;
                transform.rotation *= Quaternion.Euler(0, 0, 180);
                myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
                canChangeGravity = false;
            }
            else if(Input.GetKeyUp(KeyCode.LeftArrow)) {
                direction = Direction.LEFT;
                transform.rotation = Quaternion.identity;
                transform.rotation *= Quaternion.Euler(0, 0, -90);
                myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
                canChangeGravity = false;
            }
            else if(Input.GetKeyUp(KeyCode.RightArrow)) {
                direction = Direction.RIGHT;
                transform.rotation = Quaternion.identity;
                transform.rotation *= Quaternion.Euler(0, 0, 90);
                myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
                canChangeGravity = false;
            }
            else if(Input.GetKeyUp(KeyCode.DownArrow)) {
                direction = Direction.DOWN;
                transform.rotation = Quaternion.identity;
                transform.rotation *= Quaternion.Euler(0, 0, 0);
                myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
                canChangeGravity = false;
            }
        }

        switch (direction)
        {
            case Direction.UP:
                myRigidBody.velocity = playerSpeed * Time.deltaTime * Vector2.up ;
                break;
            case Direction.DOWN:
                myRigidBody.velocity = playerSpeed * Time.deltaTime * Vector2.down;
                break;
            case Direction.LEFT:
                myRigidBody.velocity = playerSpeed * Time.deltaTime * Vector2.left;
                break;
            case Direction.RIGHT:
                myRigidBody.velocity = playerSpeed * Time.deltaTime * Vector2.right;
                break;
            default:
                myRigidBody.velocity = playerSpeed * Time.deltaTime * Vector2.up;
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
                    canChangeGravity = true;
                    animator.SetTrigger("Landing");
                }
                break;
            case Direction.DOWN:
                if(contactPoint.y < playerPosition.y) {
                    canChangeGravity = true;
                    animator.SetTrigger("Landing");
                }
                break;
            case Direction.LEFT:
                if(contactPoint.x < playerPosition.x) {
                    canChangeGravity = true;
                    animator.SetTrigger("Landing");
                }
                break;
            case Direction.RIGHT:
                if(contactPoint.x > playerPosition.x) {
                    canChangeGravity = true;
                    animator.SetTrigger("Landing");
                }
                break;
            default:
                canChangeGravity = false;
                break;
        }
    }

    public void Kys() {
        transform.position = spawn;
    }

    public void NextLevel(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}

public enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT
}
 