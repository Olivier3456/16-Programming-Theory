using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public abstract class Animal : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Animator _anim;


    protected float Speed = 10;
    
    protected float RatioSpeedAnim = 5;



    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        Debug.Log("Vitesse de l'agent : " + Speed);
        _agent.speed = Speed;
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
        SetSpeedMoveAnimation(RatioSpeedAnim);
    }



    public void StopMovement()
    {
        _agent.isStopped = true;
        _anim.SetFloat("Speed_f", 0);
        SetSpeedMoveAnimation(1);            // Remet la vitesse d'animation à 1 pour l'animation Idle.
    }



    protected void SetSpeedMoveAnimation(float ratio)
    {
        _anim.speed = Speed / ratio;
    }

}
