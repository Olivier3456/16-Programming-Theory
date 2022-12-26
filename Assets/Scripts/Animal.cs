using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Animal : MonoBehaviour
{
    protected NavMeshAgent _agent;    

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();        
    }



    public abstract void Move(Transform dest);
    
    
    
}
