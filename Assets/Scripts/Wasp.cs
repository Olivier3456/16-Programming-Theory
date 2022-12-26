using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Animal
{

    private float _waspSpeed = 50.0f;
    private float _ratioWaspSpeedAnim = 30.0f;

    private int _indexMovements;
    private Transform _finalDestination;


    private void Awake()
    {
        Speed = _waspSpeed;                          // Connecte la varible _waspSpeed � la property correspondante de la classe-m�re.
        RatioSpeedAnim = _ratioWaspSpeedAnim;        // Idem avec _ratioSpeedAnim.       
        _finalDestination = transform;
    }


    public override void VerifyArrivalToDestination()
    {
        Debug.Log("La m�thode override VerifyArrivalToDestination() de la classe Wasp a �t� appel�e");

        if (Vector3.Distance(transform.position, _finalDestination.position) < 0.2f)
        {

            Debug.Log("L'abeille est arriv�e � destination.");
            
            StopMovement();
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
            SetSpeedAnimation(RatioSpeedAnim);
            StartCoroutine(RandomMove());
        }
        else if (_indexMovements == 5)
        {
            _agent.SetDestination(_finalDestination.position);            
        }
    }


    public override void Move(Transform dest)
    {
        Debug.Log("La m�thode override Move() de la classe Wasp a �t� appel�e.");

        _finalDestination = dest;
        _indexMovements = 0;
        StartCoroutine(RandomMove());
    }


    private Transform SetRandomDestination()
    {
        GameObject result = new GameObject();
        result.transform.position = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
        return result.transform;
    }

}
