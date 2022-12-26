using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Animal
{
    [SerializeField] private float _spiderSpeed;
    [SerializeField] private float _ratioSpeedAnim;
    

    private void Start()
    {
        Speed = _spiderSpeed;                         // Connecte la varible _speed SerializeField à celle de la classe-mère.
        RatioSpeedAnimBase= _ratioSpeedAnim;        // Idem avec _ratioSpeedAnim.             
    }

}

