using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDescriptionUI : MonoBehaviour
{
    public BuildingCardDisplay buildingCardDisplay;
    public FacultyCardDisplay facultyCardDisplay;
    public StudentCardDisplay studentCardDisplay;


    // Start is called before the first frame update
    void Start()
    {
        ResetUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetUI()
    {
        buildingCardDisplay.gameObject.SetActive(false);
        facultyCardDisplay.gameObject.SetActive(false);
        studentCardDisplay.gameObject.SetActive(false);
    }

    public void DisplayCard(CardDisplay cardDisplay)
    {
        switch (cardDisplay.card.type)
        {
            case Card.Type.Building:
                buildingCardDisplay.card = cardDisplay.card;
                buildingCardDisplay.gameObject.SetActive(true);
                buildingCardDisplay.DisplayInformation();
                break;
            case Card.Type.Faculty:
                facultyCardDisplay.card = cardDisplay.card;
                facultyCardDisplay.gameObject.SetActive(true);
                facultyCardDisplay.DisplayInformation();
                break;
            case Card.Type.Student:
                studentCardDisplay.card = cardDisplay.card;
                studentCardDisplay.gameObject.SetActive(true);
                studentCardDisplay.DisplayInformation();
                break;
            default:
                Debug.Log("Cannot show card description. Wrong cad type");
                break;
        }
    }

}
