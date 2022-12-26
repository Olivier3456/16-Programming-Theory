using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Animal
{

    private float _waspSpeed = 50.0f;
    private float _ratioWaspSpeedAnim = 30.0f;

    
    private void Awake()
    {
        Speed = _waspSpeed;                          // Connecte la varible _waspSpeed � la property correspondante de la classe-m�re.
        RatioSpeedAnim = _ratioWaspSpeedAnim;        // Idem avec _ratioSpeedAnim.       

    }


    public override void VerifyArrivalToDestination()
    {
        if (Vector3.Distance(transform.position, _agent.destination) < 0.2f)
        {
            Debug.Log("La m�thode override VerifyArrivalToDestination() de la classe Wasp a �t� appel�e");
            StopMovement();
        }
    }



    public override void Move(Transform dest)
    {
       Debug.Log("La m�thode override Move() de la classe Wasp a �t� appel�e. Destination al�atoire.");

        _agent.isStopped = false;
        _agent.SetDestination(SetRandomDestination().position);
        _anim.SetFloat("Speed_f", 1);
        SetSpeedAnimation(RatioSpeedAnim);
    }

    private Transform SetRandomDestination()
    {
        GameObject result = new GameObject();
        result.transform.position = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
        return result.transform;
    }

}
