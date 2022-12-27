using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Animal          // INHERITANCE
{

    private float _waspSpeed = 50.0f;
    private float _ratioWaspSpeedAnim = 30.0f;

    private int _indexMovements;
    private Transform _finalDestination;


    private void Awake()
    {
        Speed = _waspSpeed;                          // INHERITANCE
        RatioSpeedAnim = _ratioWaspSpeedAnim;        // INHERITANCE   
        _finalDestination = transform;
    }


    public override void VerifyArrivalToDestination()           // POLYMORPHISM
    {
        Debug.Log("La méthode override VerifyArrivalToDestination() de la classe Wasp a été appelée");

        if (Vector3.Distance(transform.position, _finalDestination.position) < 0.5f)
        {

            Debug.Log("L'abeille est arrivée à destination.");
            _audioSource.Stop();
            StopMovement();         // INHERITANCE
        }
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
        Debug.Log("La méthode override Move() de la classe Wasp a été appelée.");

        _finalDestination = dest;
        _indexMovements = 0;
        _audioSource.Play();
        StartCoroutine(RandomMove());
    }


    private Transform SetRandomDestination()            // ABSTRACTION
    {
        GameObject result = new GameObject();
        result.transform.position = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
        return result.transform;
    }

}
