using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene($"Level{level}");
    }

    public void LeaveApplication()
    {
        Application.Quit();
    }
}
