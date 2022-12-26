using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Animal
{
    
    [SerializeField] private float _spiderSpeed;
    [SerializeField] private float _ratioSpiderSpeedAnim;
    
    
    private void Start()
    {
        Speed = _spiderSpeed;                         // Connecte la varible _speed SerializeField � celle de la classe-m�re.
        RatioSpeedAnim = _ratioSpiderSpeedAnim;        // Idem avec _ratioSpeedAnim.             
    }
    
}

