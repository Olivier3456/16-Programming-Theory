using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Animal
{
    [SerializeField] private float _spiderSpeed;

    private void Start()
    {
        _agent.speed = _spiderSpeed;
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, _agent.destination) < 1.0f)
        { _agent.isStopped = true; }
    }


    public override void Move(Transform dest)
    {
        _agent.isStopped = false;
        _agent.SetDestination(dest.position);
    }
}

