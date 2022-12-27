using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Animal            // INHERITANCE
{
    
    private float _spiderSpeed = 10.0f;
    private float _ratioSpiderSpeedAnim = 5.0f;
    
    
    private void Awake()
    {
        Speed = _spiderSpeed;                          // INHERITANCE
        RatioSpeedAnim = _ratioSpiderSpeedAnim;        // INHERITANCE          
    }
    
}

