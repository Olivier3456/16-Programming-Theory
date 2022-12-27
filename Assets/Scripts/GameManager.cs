using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{   
    private Transform _destination;    
   
    private GameObject _selectedAnimal;

    private TextMeshProUGUI _selectedAnimalText;

    void Start()
    {     
        _destination = transform;
        _selectedAnimalText = GameObject.Find("SelectedAnimal Text").GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) ClickAction();
    }


    public void ClickAction()   // ABSTRACTION
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {
            Debug.Log("Le joueur a cliqué sur : " + hit.transform.gameObject.name);


            if (hit.transform.CompareTag("Animal"))
            {
                _selectedAnimal = hit.transform.gameObject;

                ChangeText("Selected animal: " + hit.transform.gameObject.name, Color.white);
            }
            else if (_selectedAnimal == null) ChangeText(Color.red);

            else if (hit.transform.gameObject.name == "Ground")
            {
                _destination.position = hit.point;
                _selectedAnimal.GetComponent<Animal>().Move(_destination);
            }            
        }        
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
