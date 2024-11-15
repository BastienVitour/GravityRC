using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;
    public SpriteRenderer spriteRenderer;
    public AudioSource buttonPress;
    public AudioSource doorOpen;
    public bool hasBeenPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        buttonPress = sources[0];
        doorOpen = sources[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !hasBeenPressed) // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            StartCoroutine(PlayButtonSound());
            spriteRenderer.color = Color.green;
            Destroy(door);
            hasBeenPressed = true;
            doorOpen.Play();
        }
    }
    
    IEnumerator PlayButtonSound(){
        buttonPress.Play();
        yield return new WaitForSeconds(5f);
        //yield return new WaitWhile (()=> buttonPress.isPlaying);
    }
}
