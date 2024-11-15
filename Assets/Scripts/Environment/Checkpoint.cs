using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector2 pointupdate;

    public SpriteRenderer spriteRenderer;
    public Sprite checkpointOn;
    public AudioSource audioSource;
    private bool isCheckpointOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !isCheckpointOn) // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            pointupdate = new Vector2( transform.position.x,transform.position.y);
            audioSource.Play();
            other.GetComponent<CharacterScript>().spawn = pointupdate;
            spriteRenderer.sprite = checkpointOn;
            isCheckpointOn = true;
        }
    }
}
