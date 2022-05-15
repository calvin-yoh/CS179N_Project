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
        switch (cardDisplay.GetCardType())
        {
            case Card.Type.Building:
                buildingCardDisplay.card = cardDisplay.card;
                buildingCardDisplay.CopyInformation(cardDisplay as BuildingCardDisplay);
                // buildingCardDisplay.SetUpInformation();
                buildingCardDisplay.gameObject.SetActive(true);
                buildingCardDisplay.DisplayInformation();
                break;
            case Card.Type.Faculty:
                facultyCardDisplay.card = cardDisplay.card;
                facultyCardDisplay.CopyInformation(cardDisplay as FacultyCardDisplay);
                // facultyCardDisplay.SetUpInformation();
                facultyCardDisplay.gameObject.SetActive(true);
                facultyCardDisplay.DisplayInformation();
                break;
            case Card.Type.Student:
                studentCardDisplay.card = cardDisplay.card;
                studentCardDisplay.CopyInformation(cardDisplay as StudentCardDisplay);
                // studentCardDisplay.SetUpInformation();
                studentCardDisplay.gameObject.SetActive(true);
                studentCardDisplay.DisplayInformation();
                break;
            default:
                Debug.Log("Cannot show card description. Wrong card type");
                break;
        }
    }

}
