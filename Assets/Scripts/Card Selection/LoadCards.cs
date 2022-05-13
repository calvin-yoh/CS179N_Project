using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCards : MonoBehaviour
{
    public float gridWidth = 1300f;
    public float rowSize = 5f;

    

    List<BuildingCard> BuildingCards = new List<BuildingCard>();
    List<StudentCard> StudentCards = new List<StudentCard>();
    List<FacultyCard> FacultyCards = new List<FacultyCard>();

    public GameObject BuildingCardDisplayPrefab;
    public GameObject StudentCardDisplayPrefab;
    public GameObject FacultyCardDisplayPrefab;

    void displayStudentCard(StudentCard card){
        var go = Instantiate(StudentCardDisplayPrefab, transform.position, transform.rotation);
        go.GetComponent<StudentCardDisplay>().card = card;
        go.GetComponent<StudentCardDisplay>().SetUpInformation();
        go.GetComponent<StudentCardDisplay>().DisplayInformation();

        go.transform.SetParent(this.transform);
        if (gameObject.name == "Library Grid"){
            Destroy(go.GetComponent<DragAndDrop>());
        }
    }

    void displayFacultyCard(FacultyCard card){
        var go = Instantiate(FacultyCardDisplayPrefab, transform.position, transform.rotation);
        go.GetComponent<FacultyCardDisplay>().card = card;
        go.GetComponent<FacultyCardDisplay>().SetUpInformation();
        go.GetComponent<FacultyCardDisplay>().DisplayInformation();

        go.transform.SetParent(this.transform);
        if (gameObject.name == "Library Grid"){
            Destroy(go.GetComponent<DragAndDrop>());
        }
    }

    void displayBuildingCard(BuildingCard card){
        var go = Instantiate(BuildingCardDisplayPrefab, transform.position, transform.rotation);
        go.GetComponent<BuildingCardDisplay>().card = card;
        go.GetComponent<BuildingCardDisplay>().SetUpInformation();
        go.GetComponent<BuildingCardDisplay>().DisplayInformation();

        go.transform.SetParent(this.transform);

        if (gameObject.name == "Library Grid"){
            Destroy(go.GetComponent<DragAndDrop>());
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {   
        // Loading faculty cards (NO FACULTY CARDS YET);

        // Loading student cards
        Object[] R_ArtStudentCards = Resources.LoadAll("Cards/StudentCards/Art Students", typeof(StudentCard));
        Object[] R_AthleticStudentCards = Resources.LoadAll("Cards/StudentCards/Athletic Studnets", typeof(StudentCard));
        Object[] R_EngineeringStudentCards = Resources.LoadAll("Cards/StudentCards/Engineering Students", typeof(StudentCard));
        Object[] R_StaffStudentCards = Resources.LoadAll("Cards/StudentCards/Staff Students", typeof(StudentCard));
        
        // Loading Buiding cards.
        Object[] R_BuildingCards = Resources.LoadAll("Cards/BuildingCards", typeof(BuildingCard));


        // Adding all the student cards to the StudentCards list.
        foreach(Object x in R_ArtStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
        }

        foreach(Object x in R_AthleticStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
        }

        foreach(Object x in R_EngineeringStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
        }

        foreach(Object x in R_StaffStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
        }

        // Adding all building cards
        foreach(Object x in R_BuildingCards){
            BuildingCard card = (BuildingCard) x;
            BuildingCards.Add(card);
        }



        // Displaying all cards.
        StudentCards.ForEach(card => {
            displayStudentCard(card);
        });

        BuildingCards.ForEach(card => {
            displayBuildingCard(card);
        });



        Debug.Log("StudentCards: " + StudentCards.Count);
        Debug.Log("BuildingCards: " + BuildingCards.Count);


        // Resizing of the Grid canvas.
        RectTransform rec = GetComponent<RectTransform>();

        float cardHeight = 375f;


        float rows = Mathf.Floor((BuildingCards.Count + StudentCards.Count + FacultyCards.Count) / rowSize);




        float new_height = (cardHeight * (rows + 1));
        

        rec.sizeDelta = new Vector2(gridWidth, new_height);

        rec.position = new Vector3(rec.position.x, -(new_height / 2), 0);

    }
}
