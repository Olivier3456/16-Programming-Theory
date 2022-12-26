using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{   
    private Transform _destination;
    public Transform Destination { get { return _destination; } }

    private GameObject _animalSpawned;

    void Start()
    {
        _animalSpawned = GameObject.FindWithTag("Player");
        _destination = transform;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SetDestination();
    }


    public void SetDestination()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {            
            _destination.position = hit.point;
            _animalSpawned.GetComponent<Spider>().Move(_destination);
        }
    }

}
