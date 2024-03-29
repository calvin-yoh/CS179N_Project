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
                buildingCardDisplay.CopyInformationUI(cardDisplay as BuildingCardDisplay);
                // buildingCardDisplay.SetUpInformation();
                buildingCardDisplay.gameObject.SetActive(true);
                buildingCardDisplay.DisplayInformationUI();
                break;
            case Card.Type.Faculty:
                facultyCardDisplay.card = cardDisplay.card;
                facultyCardDisplay.CopyInformationUI(cardDisplay as FacultyCardDisplay);
                // facultyCardDisplay.SetUpInformation();
                facultyCardDisplay.gameObject.SetActive(true);
                facultyCardDisplay.DisplayInformationUI();
                break;
            case Card.Type.Student:
                studentCardDisplay.card = cardDisplay.card;
                studentCardDisplay.CopyInformationUI(cardDisplay as StudentCardDisplay);
                // studentCardDisplay.SetUpInformation();
                studentCardDisplay.gameObject.SetActive(true);
                studentCardDisplay.DisplayInformationUI();
                break;
            default:
                Debug.Log("Cannot show card description. Wrong card type");
                break;
        }
    }

}
