using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Animator _anim;
    protected AudioSource _audioSource;


    private float _speed;                    // ENCAPSULATION
    [HideInInspector] public float Speed     // ENCAPSULATION
    {
        get { return _speed; }
        set { if (value >= 1.0f && value <= 50.0f) _speed = value;
            else Debug.LogError("_speed ne peut pas avoir une valeur inférieure à 1 ou supérieure à 50.");
        }
    }
        
    private float _ratioSpeedAnim;                      // ENCAPSULATION
    [HideInInspector] public float RatioSpeedAnim       // ENCAPSULATION
    {
        get { return _ratioSpeedAnim; }
        set {
            if (value >= 0.1f && value <= 50.0f) _ratioSpeedAnim = value;
            else Debug.LogError("_ratioSpeedAnim ne peut pas avoir une valeur inférieure à 0.1 ou supérieure à 50.");
        }
    }


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();        
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        VerifyArrivalToDestination();
    }


    public void FastSpeed()
    {           
        _agent.speed = Speed * 2;
        _anim.speed = RatioSpeedAnim * 4;
        _audioSource.pitch = 1.25f;
    }

    public void ResetSpeed()
    {
        _agent.speed = Speed ;
        _anim.speed = RatioSpeedAnim;
        _audioSource.pitch = 0.75f;
    }


    public virtual void VerifyArrivalToDestination()          // ABSTRACTION
    {
        if (Vector3.Distance(transform.position, _agent.destination) < 0.8f)
        {
            ResetSpeed();
            StopMovement();
        }
    }


    public virtual void Move(Transform dest)          // ABSTRACTION
    {
        _agent.isStopped = false;
        _agent.SetDestination(dest.position);
        _anim.SetFloat("Speed_f", 1);
        SetSpeedAnimation(RatioSpeedAnim);
        _audioSource.Play();        
    }



    public void StopMovement()             // ABSTRACTION
    {
        _agent.isStopped = true;
        _anim.SetFloat("Speed_f", 0);
        SetSpeedAnimation(Speed);            // Remet la vitesse d'animation à 1 pour l'animation Idle.
        _audioSource.Stop();
    }



    protected void SetSpeedAnimation(float ratio)       // ABSTRACTION
    {
        _anim.speed = Speed / ratio;
    }

}
