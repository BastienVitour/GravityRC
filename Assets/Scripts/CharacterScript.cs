using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Collider2D myCollider;
    public Direction direction;
    private Camera mainCamera;
    public int playerSpeed = 500;
    private bool canChangeGravity = false;

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
                myRigidBody.velocity = Vector2.up * playerSpeed * Time.deltaTime;
                break;
            case Direction.DOWN:
                myRigidBody.velocity = Vector2.down * playerSpeed * Time.deltaTime;
                break;
            case Direction.LEFT:
                myRigidBody.velocity = Vector2.left * playerSpeed * Time.deltaTime;
                break;
            case Direction.RIGHT:
                myRigidBody.velocity = Vector2.right * playerSpeed * Time.deltaTime;
                break;
            default:
                myRigidBody.velocity = Vector2.down * playerSpeed * Time.deltaTime;
                break;
        }

        Vector3 gameObjectPosition = gameObject.transform.position;
        mainCamera.transform.position = new Vector3(gameObjectPosition.x, gameObjectPosition.y, -10);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 playerPosition = gameObject.transform.position;
        Vector3 contactPoint = other.GetContact(0).point;
        switch (direction)
        {
            case Direction.UP:
                if(contactPoint.y > playerPosition.y) {
                    canChangeGravity = true;
                }
                break;
            case Direction.DOWN:
                if(contactPoint.y < playerPosition.y) {
                    canChangeGravity = true;
                }
                break;
            case Direction.LEFT:
                if(contactPoint.x < playerPosition.x) {
                    canChangeGravity = true;
                }
                break;
            case Direction.RIGHT:
                if(contactPoint.x > playerPosition.x) {
                    canChangeGravity = true;
                }
                break;
            default:
                canChangeGravity = false;
                break;
        }
    }
}

public enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT
}
