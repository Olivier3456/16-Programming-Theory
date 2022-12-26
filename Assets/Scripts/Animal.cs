using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public abstract class Animal : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Animator _anim;

    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { if (value > 1 && value < 20) _speed = value; }
    }

    private float _ratioSpeedAnimBase;
    public float RatioSpeedAnimBase
    {
        get { return _ratioSpeedAnimBase; }
        set { if (value > 0.1f && value < 10.0f) _ratioSpeedAnimBase = value; }
    }



    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        _agent.speed = _speed;
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, _agent.destination) < 0.5f)        // Si l'araignée est arrivée à sa destination...
        {
            StopMovement();
        }
    }


    public void Move(Transform dest)
    {
        _agent.isStopped = false;
        _agent.SetDestination(dest.position);
        _anim.SetFloat("Speed_f", 1);
        SetSpeedMoveAnimation(_ratioSpeedAnimBase);
    }



    public void StopMovement()
    {
        _agent.isStopped = true;
        _anim.SetFloat("Speed_f", 0);
        SetSpeedMoveAnimation(1);            // Remet la vitesse d'animation à 1 pour l'animation Idle.
    }



    protected void SetSpeedMoveAnimation(float ratio)
    {
        _anim.speed = _speed / ratio;
    }

}
