using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCards : MonoBehaviour
{
    public GameObject BuildingCardDisplayPrefab;
    public GameObject StudentCardDisplayPrefab;
    public GameObject FacultyCardDisplayPrefab;
    public float cardSize;

    public void Start(){
        foreach(var card in CardsManager.instance.getAllCards()){
            switch(card.type){
                case Card.Type.Building:
                    var buildingCard = (BuildingCard)card;
                    var buildingCardDisplay = Instantiate(BuildingCardDisplayPrefab, transform);
                    buildingCardDisplay.GetComponent<BuildingCardDisplay>().card = buildingCard;

                    buildingCardDisplay.GetComponent<BuildingCardDisplay>().SetUpInformationUI();
                    buildingCardDisplay.GetComponent<BuildingCardDisplay>().DisplayInformationUI();

                    break;
                case Card.Type.Student:
                    var studentCard = (StudentCard)card;
                    var studentCardDisplay = Instantiate(StudentCardDisplayPrefab, transform);
                    studentCardDisplay.GetComponent<StudentCardDisplay>().card = studentCard;

                    studentCardDisplay.GetComponent<StudentCardDisplay>().SetUpInformationUI();
                    studentCardDisplay.GetComponent<StudentCardDisplay>().DisplayInformationUI();
                    break;
                case Card.Type.Faculty:
                    var facultyCard = (FacultyCard)card;
                    var facultyCardDisplay = Instantiate(FacultyCardDisplayPrefab, transform);
                    facultyCardDisplay.GetComponent<FacultyCardDisplay>().card = facultyCard;

                    facultyCardDisplay.GetComponent<FacultyCardDisplay>().SetUpInformationUI();
                    facultyCardDisplay.GetComponent<FacultyCardDisplay>().DisplayInformationUI();
                    break;
            }
        }

        //resize the rectTransform to fit all the cards vertically
        int columns = 5;
        int rows = Mathf.CeilToInt(transform.childCount / (columns - 1));
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, cardSize * (rows + 1));
    }
}
