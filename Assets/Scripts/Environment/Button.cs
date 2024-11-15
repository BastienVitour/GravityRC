using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public bool hasBeenPressed = false;

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
        if (other.tag == "Player" && !hasBeenPressed) // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            audioSource.Play();
            spriteRenderer.color = Color.green;
            Destroy(door);
            hasBeenPressed = true;
        }
    }
}
