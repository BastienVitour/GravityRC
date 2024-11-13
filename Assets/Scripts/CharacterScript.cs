using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public ConstantForce2D myConstantForce;
    public Direction direction;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.DOWN;
        mainCamera = Camera.main;
        // float gravityForceAmount = myRigidBody.mass * Physics2D.gravity.magnitude;
        // myConstantForce.force = new Vector2 (0, -gravityForceAmount); // gravity to the left
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
                myRigidBody.velocity = Vector2.up * 10;
                break;
            case Direction.DOWN:
                myRigidBody.velocity = Vector2.down * 10;
                break;
            case Direction.LEFT:
                myRigidBody.velocity = Vector2.left * 10;
                break;
            case Direction.RIGHT:
                myRigidBody.velocity = Vector2.right * 10;
                break;
            default:
                myRigidBody.velocity = Vector2.down * 10;
                break;
        }

        Vector3 gameObjectPosition = gameObject.transform.position;
        mainCamera.transform.position = new Vector3(gameObjectPosition.x, gameObjectPosition.y, -10);
    }
}

public enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT
}
