using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeckSave{
    public List<string> cards;
}


public class CardsManager : MonoBehaviour
{
    private static string currentDeckPath;
    private static Dictionary<string, Card> cardDict = new Dictionary<string, Card>();
    public static GameObject cardsGrid;
    public static GameObject deckGrid;

    void Start()
    {   
        currentDeckPath = Application.dataPath + "/Data/currentDeck.json";
        cardsGrid = GameObject.Find("Cards Grid");
        deckGrid = GameObject.Find("Deck Grid");

        // Loading student cards
        Object[] R_ArtStudentCards = Resources.LoadAll("Cards/StudentCards/Art Students", typeof(StudentCard));
        Object[] R_AthleticStudentCards = Resources.LoadAll("Cards/StudentCards/Athletic Students", typeof(StudentCard));
        Object[] R_EngineeringStudentCards = Resources.LoadAll("Cards/StudentCards/Engineering Students", typeof(StudentCard));
        Object[] R_StaffStudentCards = Resources.LoadAll("Cards/StudentCards/Staff Students", typeof(StudentCard));

        // Loading Faculty cards
        Object[] R_Art_FacultyCards = Resources.LoadAll("Cards/FacultyCards/ArtsFaculty", typeof(FacultyCard));
        Object[] R_Athletic_FacultyCards = Resources.LoadAll("Cards/FacultyCards/AthleticsFaculty", typeof(FacultyCard));
        Object[] R_Engineering_FacultyCards = Resources.LoadAll("Cards/FacultyCards/EngineeringFaculty", typeof(FacultyCard));
        Object[] R_Staff_FacultyCards = Resources.LoadAll("Cards/FacultyCards/StaffFaculty", typeof(FacultyCard));

        // Loading Buiding cards.
        Object[] R_BuildingCards = Resources.LoadAll("Cards/BuildingCards", typeof(BuildingCard));

        
        List<Object[]> R_cards = new List<Object[]>();
        R_cards.Add(R_ArtStudentCards);
        R_cards.Add(R_AthleticStudentCards);
        R_cards.Add(R_EngineeringStudentCards);
        R_cards.Add(R_StaffStudentCards);
        R_cards.Add(R_Art_FacultyCards);
        R_cards.Add(R_Athletic_FacultyCards);
        R_cards.Add(R_Engineering_FacultyCards);
        R_cards.Add(R_Staff_FacultyCards);
        R_cards.Add(R_BuildingCards);




        // Adding all the cards to the card dictionary.
        foreach (Object[] R_card in R_cards)
        {
            foreach (Object R_cardObj in R_card)
            {
                var card = (Card)R_cardObj;
                if(!cardDict.ContainsKey(card.name)){
                cardDict.Add(card.name, card);
            }
            }
        }




        //check if the currenDeckPath exists if not create it.
        if(!File.Exists(currentDeckPath)){
            File.WriteAllText(currentDeckPath, "");
        }
        // Load all the cards to be displayed.
        cardsGrid.GetComponent<LoadCards>().loadAll();
        // Load the cards in the current deck.
        loadDeck(currentDeckPath);
    }

    public static List<Card> getAllCards(){
        List<Card> cards = new List<Card>();
        foreach(KeyValuePair<string, Card> entry in cardDict){
            cards.Add(entry.Value);
        }
        return cards;
    }
    
    public static Card getCard(string name){
        if(cardDict.ContainsKey(name)){
            return cardDict[name];
        }
        return null;
    }

    public static void saveCurrentDeck(){
        DeckSave deckSave = new DeckSave();
        deckSave.cards = new List<string>(); 
        foreach(Transform card in deckGrid.transform){
            switch(card.gameObject.GetComponent<DragAndDrop>().type){
                case Card.Type.Building:
                    deckSave.cards.Add(card.gameObject.GetComponent<BuildingCardDisplay>().card.name);
                    break;
                case Card.Type.Student:
                    deckSave.cards.Add(card.gameObject.GetComponent<StudentCardDisplay>().card.name);
                    break;
                case Card.Type.Faculty:
                    deckSave.cards.Add(card.gameObject.GetComponent<FacultyCardDisplay>().card.name);
                    break;
            }
        }
        string json = JsonUtility.ToJson(deckSave);
        File.WriteAllText(currentDeckPath, json);
    }

    public static void loadDeck(string filename){
        string json;
        if(File.Exists(filename)){
            json = File.ReadAllText(filename);
        }else{ return; }

        DeckSave deckSave = JsonUtility.FromJson<DeckSave>(json);
        foreach(string cardName in deckSave.cards){
            var card = getCard(cardName);
            if(card != null){
                var cardDisplay = Instantiate(cardsGrid.GetComponent<LoadCards>().getPrefab(card.type));
                switch(card.type){
                    case Card.Type.Building:
                        cardDisplay.GetComponent<BuildingCardDisplay>().card = card;
                        cardDisplay.GetComponent<BuildingCardDisplay>().SetUpInformation();
                        cardDisplay.GetComponent<BuildingCardDisplay>().DisplayInformation();
                        deckGrid.GetComponent<DropContainer>().addCard(cardDisplay);
                        break;
                    case Card.Type.Student:
                        cardDisplay.GetComponent<StudentCardDisplay>().card = card;
                        cardDisplay.GetComponent<StudentCardDisplay>().SetUpInformation();
                        cardDisplay.GetComponent<StudentCardDisplay>().DisplayInformation();
                        deckGrid.GetComponent<DropContainer>().addCard(cardDisplay);
                        break;
                    case Card.Type.Faculty:
                        cardDisplay.GetComponent<FacultyCardDisplay>().card = card;
                        cardDisplay.GetComponent<FacultyCardDisplay>().SetUpInformation();
                        cardDisplay.GetComponent<FacultyCardDisplay>().DisplayInformation();
                        deckGrid.GetComponent<DropContainer>().addCard(cardDisplay);
                        break;
                }
            }
        }
    }

    public static List<Card> getDeckCards(){
        List<Card> cards = new List<Card>();
        foreach(Transform card in deckGrid.transform){
            switch(card.gameObject.GetComponent<DragAndDrop>().type){
                case Card.Type.Building:
                    cards.Add(card.gameObject.GetComponent<BuildingCardDisplay>().card);
                    break;
                case Card.Type.Student:
                    cards.Add(card.gameObject.GetComponent<StudentCardDisplay>().card);
                    break;
                case Card.Type.Faculty:
                    cards.Add(card.gameObject.GetComponent<FacultyCardDisplay>().card);
                    break;
            }
        }
        return cards;
    }
}
