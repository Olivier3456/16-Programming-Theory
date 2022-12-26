using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Animator _anim;


    private float _speed;
   [HideInInspector] public float Speed
    {
        get { return _speed; }
        set { if (value >= 1.0f && value <= 50.0f) _speed = value;
            else Debug.LogError("_speed ne peut pas avoir une valeur inférieure à 1 ou supérieure à 50.");
        }
    }
        
    private float _ratioSpeedAnim;
    [HideInInspector] public float RatioSpeedAnim
    {
        get { return _ratioSpeedAnim; }
        set {
            if (value >= 0.1f && value <= 50.0f) _ratioSpeedAnim = value;
            else Debug.LogError("_ratioSpeedAnim ne peut pas avoir une valeur inférieure à 0.1 ou supérieure à 50.");
        }
    }



    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        Debug.Log("Vitesse de l'agent : " + Speed);
        _agent.speed = Speed;
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, _agent.destination) < 0.2f)        // Si l'animal est arrivée à sa destination...
        {
            StopMovement();
        }
    }


    public virtual void Move(Transform dest)
    {
        Debug.Log("La méthode Move() de la classe de base Animal a été appelée.");
        _agent.isStopped = false;
        _agent.SetDestination(dest.position);
        _anim.SetFloat("Speed_f", 1);
        SetSpeedAnimation(RatioSpeedAnim);
    }



    public void StopMovement()
    {
        _agent.isStopped = true;
        _anim.SetFloat("Speed_f", 0);
        SetSpeedAnimation(Speed);            // Remet la vitesse d'animation à 1 pour l'animation Idle.
    }



    protected void SetSpeedAnimation(float ratio)
    {
        _anim.speed = Speed / ratio;
    }

}
