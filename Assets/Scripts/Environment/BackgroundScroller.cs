using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    
    public float scrollSpeed;
    public float offset;
    private Material material;
    
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (scrollSpeed * Time.deltaTime) / 10f;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
