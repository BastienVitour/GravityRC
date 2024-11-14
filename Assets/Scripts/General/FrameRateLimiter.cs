using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int frameRateTarget = 60;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRateTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.targetFrameRate >= frameRateTarget) {
            Application.targetFrameRate = frameRateTarget;
        }
    }
}
