using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject respawn;
    private Respawn spawn;

    Vector2 pointupdate;
    // Start is called before the first frame update
    void Start()
    {
        spawn = respawn.GetComponent<Respawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            pointupdate = new Vector2( transform.position.x,transform.position.y);
            spawn.spawn = pointupdate;
        }
    }
}
