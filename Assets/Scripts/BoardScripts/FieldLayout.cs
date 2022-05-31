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

    // Gets inactive cards too
    public List<BuildingCardDisplay> GetBuildingCards(){
        return buildingCardDisplays;
    }
    public List<FacultyCardDisplay> GetFacultyCards(){
        return facultyCardDisplays;
    }
    public List<StudentCardDisplay> GetStudentCards(){
        return studentCardDisplays;
    }

    public List<BuildingCardDisplay> GetActiveBuildingCards(){
        List<BuildingCardDisplay> newList = new List<BuildingCardDisplay>();
        foreach (BuildingCardDisplay bd in buildingCardDisplays){
            if (bd.inPlay){
                newList.Add(bd);
            }
        }
        return newList;
    }
    public List<FacultyCardDisplay> GetActiveFacultyCards(){
        List<FacultyCardDisplay> newList = new List<FacultyCardDisplay>();
        foreach (FacultyCardDisplay fd in facultyCardDisplays){
            if (fd.inPlay){
                newList.Add(fd);
            }
        }
        return newList;
    }
    public List<StudentCardDisplay> GetActiveStudentCards(){
        List<StudentCardDisplay> newList = new List<StudentCardDisplay>();
        foreach (StudentCardDisplay cd in studentCardDisplays){
            if (cd.inPlay){
                newList.Add(cd);
            }
        }
        return newList;
    }

    public CardDisplay GetRandomCard(Card.Type type){
        switch (type){
            case Card.Type.Building:
                List<BuildingCardDisplay> bds = GetActiveBuildingCards();
                if (bds.Count > 0) return bds[Random.Range(0, bds.Count)];
                break;
            case Card.Type.Faculty:
                List<FacultyCardDisplay> fds = GetActiveFacultyCards();
                if (fds.Count > 0) return fds[Random.Range(0, fds.Count)];
                break;
            case Card.Type.Student:
                List<StudentCardDisplay> sds = GetActiveStudentCards();
                if (sds.Count > 0) return sds[Random.Range(0, sds.Count)];
                break;
            default:
                Debug.Log("Target type not found");
                break;
        }
        return null;
    }

    public void ReactivateCards(){
        foreach (StudentCardDisplay student in GetActiveStudentCards()){
            student.ReactivateCard();
        }
        foreach (FacultyCardDisplay faculty in GetActiveFacultyCards()){
            faculty.ReactivateCard();
        }
    }

    public void ReduceStudentCardDurations(){
        foreach (StudentCardDisplay stud in studentCardDisplays){
            if (stud != null && stud.inPlay){
                stud.ChangeDurationBy(-1);
            }
        }
    }

    public void ReduceEffectModifiers()
    {
        foreach (StudentCardDisplay stud in studentCardDisplays)
        {
            if (stud != null && stud.inPlay)
            {
                stud.RemoveEffectModifier();
                stud.DisplayInformation();
            }
        }
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
                buildingCardDisplays[index].SetFieldLocation(index + 1);
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
                facultyCardDisplays[index].ReactivateCard();
                facultyCardDisplays[index].SetUpInformation();
                facultyCardDisplays[index].DisplayInformation();
                break;
            case Card.Type.Student:
                studentCardDisplays[index].card = newCard;
                studentCardDisplays[index].inPlay = true;
                studentCardDisplays[index].playerNumber = player;
                studentCardDisplays[index].gameObject.SetActive(true);
                studentCardDisplays[index].ReactivateCard();
                studentCardDisplays[index].SetUpInformation();
                studentCardDisplays[index].DisplayInformation();
                break;
            default:
                Debug.Log("Card type " + type + " not found");
                break;
        }
    }
}
