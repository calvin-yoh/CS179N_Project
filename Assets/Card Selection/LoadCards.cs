using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCards : MonoBehaviour
{

    // Thesse lsts are not needed right now. But they will be used later to reference cards.
    List<BuildingCard> BuildingCards = new List<BuildingCard>();
    List<StudentCard> StudentCards = new List<StudentCard>();
    List<FacultyCard> FacultyCards = new List<FacultyCard>(); // There are no cards in this list yet.


    public GameObject BuildingCardDisplayPrefab;

    void displayCard(Card generic_card){
        var go = Instantiate(BuildingCardDisplayPrefab, transform.position, transform.rotation);
        go.GetComponent<BuildingCardDisplay>().card = generic_card;
        go.GetComponent<BuildingCardDisplay>().DisplayInformation();

        go.transform.SetParent(this.transform);
    }
    
    // Start is called before the first frame update
    void Start()
    {

        // Load all the cards from assets.
        Object[] R_BuildingCards = Resources.LoadAll("Cards/BuildingCards", typeof(BuildingCard));
        Object[] R_ArtStudentCards = Resources.LoadAll("Cards/StudentCards/Art Students", typeof(StudentCard));
        Object[] R_AthleticStudentCards = Resources.LoadAll("Cards/StudentCards/Athletic Studnets", typeof(StudentCard));
        Object[] R_EngineeringStudentCards = Resources.LoadAll("Cards/StudentCards/Engineering Students", typeof(StudentCard));
        Object[] R_StaffStudentCards = Resources.LoadAll("Cards/StudentCards/Staff Students", typeof(StudentCard));


        // Adding all the student cards to the StudentCards list.
        foreach(Object x in R_ArtStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
            displayCard(card);
        }

        foreach(Object x in R_AthleticStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
            displayCard(card);
        }

        foreach(Object x in R_EngineeringStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
            displayCard(card);
        }

        foreach(Object x in R_StaffStudentCards){
            StudentCard card = (StudentCard) x;
            StudentCards.Add(card);
            displayCard(card);
        }

        // Adding all building cards
        foreach(Object x in R_BuildingCards){
            BuildingCard card = (BuildingCard) x;
            BuildingCards.Add(card);
            displayCard(card);
        }



        Debug.Log("StudentCards: " + StudentCards.Count);
        Debug.Log("BuildingCards: " + BuildingCards.Count);


        // Resizing of the Grid canvas.
        RectTransform rec = GetComponent<RectTransform>();

        float cardHeight = 400f;

        float rows = Mathf.Floor((BuildingCards.Count + StudentCards.Count + FacultyCards.Count) / 5);



        float new_height = (cardHeight * rows) + 100;
        
        rec.sizeDelta = new Vector2(1300, new_height);

        rec.position = new Vector3(0, -(new_height / 2), 0);
    }
}
