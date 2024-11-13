using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spike : MonoBehaviour
{
    public GameObject Respawn;
    private Respawn spawn;

    public GameObject Character;
    private CharacterScript characterScript;
    public UnityEvent m_killPlayer;
    void Start()
    {
        spawn = Respawn.GetComponent<Respawn>();
        characterScript = Character.GetComponent<CharacterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") // filter the objects that collide with the checkpoint. You can assign the tag in the inspector
        {
            characterScript.Kys(spawn.spawn);
        }
    }
}
