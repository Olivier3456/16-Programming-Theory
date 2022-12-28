using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private Transform _destination;

    private GameObject _selectedAnimal;

    private TextMeshProUGUI _selectedAnimalText;

    private GameObject _marker;
    private GameObject _destinationMarker;

    private float doubleClickStart = 0;
    private float doubleClickDelay = 0.3f;
    

    private bool _fastSpeedAlreadySet;
    public bool FastSpeedAlreadySet
    {
        get { return _fastSpeedAlreadySet;}
        set { _fastSpeedAlreadySet = value;}
    }

    void Start()
    {
        _destination = transform;
        _selectedAnimalText = GameObject.Find("SelectedAnimal Text").GetComponent<TextMeshProUGUI>();

        _marker = GameObject.Find("Marker");
        _destinationMarker = GameObject.Find("DestinationMarker");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickAction();
            ManageDoubleClick();
        }       
    }

    private void ManageDoubleClick()
    {
        if (Time.time - doubleClickStart < doubleClickDelay)
        {
            Debug.Log("Double click detected!");
            if (_selectedAnimal) _selectedAnimal.GetComponent<Animal>().FastSpeed();           
        }
        else
        {
            doubleClickStart = Time.time;
        }
    }


    public void ClickAction()   // ABSTRACTION
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {
            if (hit.transform.CompareTag("Animal"))
            {
                _selectedAnimal = hit.transform.gameObject;

                _marker.transform.SetParent(_selectedAnimal.transform);     // Le marker suivra l'animal sélectionné.
                _marker.transform.position = _selectedAnimal.transform.position;

                ChangeText("Selected animal: " + hit.transform.gameObject.name, Color.white);
            }
            else if (_selectedAnimal == null) ChangeText(Color.red);

            else if (hit.transform.gameObject.name == "Ground")
            {
                _destination.position = hit.point;
                _selectedAnimal.GetComponent<Animal>().Move(_destination);
                _destinationMarker.transform.position = hit.point;
                StartCoroutine(ManageDestinationMarker(hit.point));
            }
        }
    }

    IEnumerator ManageDestinationMarker(Vector3 position)
    {
        _destinationMarker.transform.position = position;
        _destinationMarker.gameObject.SetActive(true);       
        yield return new WaitForSeconds(0.1f);
        _destinationMarker.gameObject.SetActive(false);
    }


    public void ChangeText(string text, Color color)        // POLYMORPHISM
    {
        _selectedAnimalText.text = text;
        _selectedAnimalText.color = color;
    }

    public void ChangeText(string text)                     // POLYMORPHISM
    {
        _selectedAnimalText.text = text;
    }

    public void ChangeText(Color color)                     // POLYMORPHISM
    {
        _selectedAnimalText.color = color;
    }


}
