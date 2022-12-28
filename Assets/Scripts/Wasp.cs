using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Animal          // INHERITANCE
{

    private float _waspSpeed = 50.0f;
    private float _ratioWaspSpeedAnim = 30.0f;

    private int _indexMovements;
    private Transform _finalDestination;


    private void Start()
    {
        Speed = _waspSpeed;                          // INHERITANCE
        RatioSpeedAnim = _ratioWaspSpeedAnim;        // INHERITANCE   
        _finalDestination = transform;
        ResetSpeed();
    }



    IEnumerator RandomMove()
    {
        yield return new WaitForSeconds(0.5f);

        if (_indexMovements <= 4)
        {
            _indexMovements++;
            _agent.isStopped = false;
            _agent.SetDestination(SetRandomDestination().position);
            _anim.SetFloat("Speed_f", 1);
            SetSpeedAnimation(RatioSpeedAnim);      // INHERITANCE
            StartCoroutine(RandomMove());
        }
        else if (_indexMovements == 5)
        {
            _agent.SetDestination(_finalDestination.position);            
        }
    }


    public override void Move(Transform dest)           // POLYMORPHISM
    {
        _finalDestination = dest;
        _indexMovements = 0;
        _audioSource.Play();
        StartCoroutine(RandomMove());
    }


    private Transform SetRandomDestination()            // ABSTRACTION
    {
        GameObject result = new GameObject();
        result.transform.position = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
        Destroy(result, 0.1f);
        return result.transform;
        
    }

}
