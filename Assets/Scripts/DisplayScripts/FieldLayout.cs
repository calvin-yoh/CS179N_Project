using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldLayout : MonoBehaviour
{
    [SerializeField] private List<BuildingCardDisplay> buildingCardDisplays = new List<BuildingCardDisplay>();
    [SerializeField] private List<StudentCardDisplay> studentCardDisplays = new List<StudentCardDisplay>();
    [SerializeField] private List<FacultyCardDisplay> facultyCardDisplays = new List<FacultyCardDisplay>();

    public Card test;

    // Start is called before the first frame update
    void Start()
    {
        //Remove all visible instances of card displays
        foreach (BuildingCardDisplay bcd in buildingCardDisplays)
            bcd.gameObject.SetActive(false);
        foreach (StudentCardDisplay scd in studentCardDisplays)
            scd.gameObject.SetActive(false);
        foreach (FacultyCardDisplay fcd in facultyCardDisplays)
            fcd.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            studentCardDisplays[0].card = test;
            studentCardDisplays[0].gameObject.SetActive(true);
        }
            
    }

    public void ActivateCard(int index, Card newCard, Card.Type type){
        switch (type){
            case Card.Type.Student:
                studentCardDisplays[index].card = newCard;
                studentCardDisplays[index].gameObject.SetActive(true);
                break;
            case Card.Type.Faculty:
                FacultyCardDisplays[index].card = newCard;
                FacultyCardDisplays[index].gameObject.SetActive(true);
                break;
            case Card.Type.Building:
                buildingCardDisplays[index].card = newCard;
                buildingCardDisplays[index].gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Card type " + type + " not found");
                break;
        }
    }
}
