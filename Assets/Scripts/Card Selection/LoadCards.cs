using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCards : MonoBehaviour
{
    public GameObject BuildingCardDisplayPrefab;
    public GameObject StudentCardDisplayPrefab;
    public GameObject FacultyCardDisplayPrefab;
    public float cardSize;

    public void loadAll(){
        foreach(var card in CardsManager.getAllCards()){
            switch(card.type){
                case Card.Type.Building:
                    var buildingCard = (BuildingCard)card;
                    var buildingCardDisplay = Instantiate(BuildingCardDisplayPrefab, transform);
                    buildingCardDisplay.GetComponent<BuildingCardDisplay>().card = buildingCard;

                    buildingCardDisplay.GetComponent<BuildingCardDisplay>().SetUpInformation();
                    buildingCardDisplay.GetComponent<BuildingCardDisplay>().DisplayInformation();

                    break;
                case Card.Type.Student:
                    var studentCard = (StudentCard)card;
                    var studentCardDisplay = Instantiate(StudentCardDisplayPrefab, transform);
                    studentCardDisplay.GetComponent<StudentCardDisplay>().card = studentCard;

                    studentCardDisplay.GetComponent<StudentCardDisplay>().SetUpInformation();
                    studentCardDisplay.GetComponent<StudentCardDisplay>().DisplayInformation();
                    break;
                case Card.Type.Faculty:
                    var facultyCard = (FacultyCard)card;
                    var facultyCardDisplay = Instantiate(FacultyCardDisplayPrefab, transform);
                    facultyCardDisplay.GetComponent<FacultyCardDisplay>().card = facultyCard;

                    facultyCardDisplay.GetComponent<FacultyCardDisplay>().SetUpInformation();
                    facultyCardDisplay.GetComponent<FacultyCardDisplay>().DisplayInformation();
                    break;
            }
        }

        //resize the rectTransform to fit all the cards vertically
        int columns = 5;
        int rows = Mathf.CeilToInt(transform.childCount / (columns - 1));
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, cardSize * (rows + 1));
    }

    public GameObject getPrefab(Card.Type type){
        switch(type){
            case Card.Type.Building:
                return BuildingCardDisplayPrefab;
            case Card.Type.Student:
                return StudentCardDisplayPrefab;
            case Card.Type.Faculty:
                return FacultyCardDisplayPrefab;
        }
        return null;
    }

}
