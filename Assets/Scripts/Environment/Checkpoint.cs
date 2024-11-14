using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector2 pointupdate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            pointupdate = new Vector2( transform.position.x,transform.position.y);
            Debug.Log($"{pointupdate.x}, {pointupdate.y}");
            other.GetComponent<CharacterScript>().spawn = pointupdate;
        }
    }
}
