using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldLayout : MonoBehaviour
{
    [SerializeField] private List<BuildingCardDisplay> buildingCardDisplays = new List<BuildingCardDisplay>();
    [SerializeField] private List<StudentCardDisplay> studentCardDisplays = new List<StudentCardDisplay>();
    [SerializeField] private List<FacultyCardDisplay> facultyCardDisplays = new List<FacultyCardDisplay>();

    public Card test;


    private void Awake()
    {
        //Remove all visible instances of card displays
        foreach (BuildingCardDisplay bcd in buildingCardDisplays)
            bcd.gameObject.SetActive(false);
        foreach (StudentCardDisplay scd in studentCardDisplays)
            scd.gameObject.SetActive(false);
        foreach (FacultyCardDisplay fcd in facultyCardDisplays)
            fcd.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public bool CheckIfOccupied(int index, Card.Type cardType){
        switch (cardType){
            case Card.Type.Building:
                return (buildingCardDisplays[index].gameObject.activeSelf);
            case Card.Type.Faculty:
                return (facultyCardDisplays[index].gameObject.activeSelf);
            case Card.Type.Student:
                return (studentCardDisplays[index].gameObject.activeSelf);
            default:
                Debug.Log("Card type " + cardType + " not found");
                return false;
        }
    }

    public void ActivateCard(int index, Card newCard, int player){
        Card.Type type = newCard.type;
        switch (type){
            case Card.Type.Building:
                buildingCardDisplays[index].card = newCard;
                buildingCardDisplays[index].inPlay = true;
                buildingCardDisplays[index].playerNumber = player;
                buildingCardDisplays[index].gameObject.SetActive(true);
                buildingCardDisplays[index].SetUpInformation();
                buildingCardDisplays[index].DisplayInformation();
                break;
            case Card.Type.Faculty:
                facultyCardDisplays[index].card = newCard;
                facultyCardDisplays[index].inPlay = true;
                facultyCardDisplays[index].playerNumber = player;
                facultyCardDisplays[index].gameObject.SetActive(true);
                facultyCardDisplays[index].SetUpInformation();
                facultyCardDisplays[index].DisplayInformation();
                break;
            case Card.Type.Student:
                studentCardDisplays[index].card = newCard;
                studentCardDisplays[index].inPlay = true;
                studentCardDisplays[index].playerNumber = player;
                studentCardDisplays[index].gameObject.SetActive(true);
                studentCardDisplays[index].SetUpInformation();
                studentCardDisplays[index].DisplayInformation();
                break;
            default:
                Debug.Log("Card type " + type + " not found");
                break;
        }
    }
}
