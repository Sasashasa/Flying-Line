using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    public int frameRate = 60;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (frameRate != Application.targetFrameRate)
        {
            Application.targetFrameRate = frameRate;
        }
    }
}
