using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Animal
{
    
    private float _spiderSpeed = 10.0f;
    private float _ratioSpiderSpeedAnim = 5.0f;
    
    
    private void Awake()
    {
        Speed = _spiderSpeed;                          // Connecte la varible _spiderSpeed � la property Speed de la classe-m�re.
        RatioSpeedAnim = _ratioSpiderSpeedAnim;        // Idem avec _ratioSpeedAnim.             
    }
    
}

