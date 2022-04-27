using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCards : MonoBehaviour
{

    // Thesse lsts are not needed right now. But they will be used later to reference cards.
    List<BuildingCard> BuildingCards = new List<BuildingCard>();
    List<StudentCard> StudentCards = new List<StudentCard>();
    List<FacultyCard> FacultyCards = new List<FacultyCard>();


    public GameObject BuildingCardDisplayPrefab;
    public GameObject StudentCardDisplayPrefab;

    void displayStudentCard(StudentCard card){
        var go = Instantiate(StudentCardDisplayPrefab, transform.position, transform.rotation);
        go.GetComponent<StudentCardDisplay>().card = card;
        go.GetComponent<StudentCardDisplay>().DisplayInformation();

        go.transform.SetParent(this.transform);
    }

    void dislayBuildingCard(BuildingCard card){
        var go = Instantiate(BuildingCardDisplayPrefab, transform.position, transform.rotation);
        go.GetComponent<BuildingCardDisplay>().card = card;
        go.GetComponent<BuildingCardDisplay>().DisplayInformation();

        go.transform.SetParent(this.transform);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Object[] R_BuildingCards = Resources.LoadAll("Cards/BuildingCards", typeof(BuildingCard));
        Object[] R_ArtStudentCards = Resources.LoadAll("Cards/StudentCards/Art Students", typeof(StudentCard));
        Object[] R_AthleticStudentCards = Resources.LoadAll("Cards/StudentCards/Athletic Studnets", typeof(StudentCard));
        Object[] R_EngineeringStudentCards = Resources.LoadAll("Cards/StudentCards/Engineering Students", typeof(StudentCard));
        Object[] R_StaffStudentCards = Resources.LoadAll("Cards/StudentCards/Staff Students", typeof(StudentCard));


        // Adding all the student cards to the StudentCards list.
        foreach(Object x in R_ArtStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
            displayStudentCard(card);
        }

        foreach(Object x in R_AthleticStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
            displayStudentCard(card);
        }

        foreach(Object x in R_EngineeringStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
            displayStudentCard(card);
        }

        foreach(Object x in R_StaffStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
            displayStudentCard(card);
        }

        // Adding all building cards
        foreach(Object x in R_BuildingCards){
            BuildingCard card = (BuildingCard) x;
            BuildingCards.Add(card);
            dislayBuildingCard(card);
        }



        Debug.Log("StudentCards: " + StudentCards.Count);
        Debug.Log("BuildingCards: " + BuildingCards.Count);


        // Resizing of the Grid canvas.
        RectTransform rec = GetComponent<RectTransform>();

        float cardHeight = 400f;

        float rows = Mathf.Floor((BuildingCards.Count + StudentCards.Count + FacultyCards.Count) / 5);



        float new_height = (cardHeight * rows) + 300;
        
        rec.sizeDelta = new Vector2(1300, new_height);

        rec.position = new Vector3(0, -(new_height / 2), 0);
    }
}
