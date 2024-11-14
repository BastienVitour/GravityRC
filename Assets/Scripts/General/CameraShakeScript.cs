using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    
    public float shakeDuration = 0.25f;
    public AnimationCurve curve;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shaking()
    {
        Vector3 originalPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / shakeDuration);
            transform.position = originalPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        
        transform.position = originalPosition;
        
    }
}
