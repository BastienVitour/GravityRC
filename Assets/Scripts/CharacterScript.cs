using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Collider2D myCollider;
    public Direction direction;
    public Vector3 gameObjectPosition;
    private Camera mainCamera;
    public int playerSpeed = 250;

    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.DOWN;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow)) {
            direction = Direction.UP;
            transform.rotation = Quaternion.identity;
            transform.rotation *= Quaternion.Euler(0, 0, 180);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow)) {
            direction = Direction.LEFT;
            transform.rotation = Quaternion.identity;
            transform.rotation *= Quaternion.Euler(0, 0, -90);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow)) {
            direction = Direction.RIGHT;
            transform.rotation = Quaternion.identity;
            transform.rotation *= Quaternion.Euler(0, 0, 90);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow)) {
            direction = Direction.DOWN;
            transform.rotation = Quaternion.identity;
            transform.rotation *= Quaternion.Euler(0, 0, 0);
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
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

        gameObjectPosition = gameObject.transform.position;
        mainCamera.transform.position = new Vector3(gameObjectPosition.x, gameObjectPosition.y, -10);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.GetContact(0).point);
    }

    public void Kys(Vector2 pos) {
        gameObject.transform.position = pos;
    }
}

public enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT
}
