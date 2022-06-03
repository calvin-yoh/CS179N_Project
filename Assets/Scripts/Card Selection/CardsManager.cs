using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[System.Serializable]
public class DeckSave{
    public List<string> cards;
}

[System.Serializable]
 public class DataSave{
    public int currentDeck; 
    public List<DeckSave> decks;
 }


public class CardsManager : MonoBehaviour
{
    public static CardsManager instance;

    private Dictionary<string, Card> cardDict = new Dictionary<string, Card>();
    private string currentDeckPath;

    public GameObject cardsGrid;
    public GameObject deckGrid;

    public GameObject buildingCardDisplayPrefab;
    public GameObject studentCardDisplayPrefab;
    public GameObject facultyCardDisplayPrefab;

    private DataSave DeckData;

    private void Awake(){
        if(instance == null){
            instance = this;
            LoadCardObjects();
        }
        else{
            Destroy(gameObject);
        }
    }


    //Loads all the cards from the cards folder.
    public void LoadCardObjects()
    {   
        // Loading student cards
        UnityEngine.Object[] R_ArtStudentCards = Resources.LoadAll("Cards/StudentCards/Art Students", typeof(StudentCard));
        UnityEngine.Object[] R_AthleticStudentCards = Resources.LoadAll("Cards/StudentCards/Athletic Students", typeof(StudentCard));
        UnityEngine.Object[] R_EngineeringStudentCards = Resources.LoadAll("Cards/StudentCards/Engineering Students", typeof(StudentCard));
        UnityEngine.Object[] R_StaffStudentCards = Resources.LoadAll("Cards/StudentCards/Staff Students", typeof(StudentCard));

        // Loading Faculty cards
        UnityEngine.Object[] R_Art_FacultyCards = Resources.LoadAll("Cards/FacultyCards/ArtsFaculty", typeof(FacultyCard));
        UnityEngine.Object[] R_Athletic_FacultyCards = Resources.LoadAll("Cards/FacultyCards/AthleticsFaculty", typeof(FacultyCard));
        UnityEngine.Object[] R_Engineering_FacultyCards = Resources.LoadAll("Cards/FacultyCards/EngineeringFaculty", typeof(FacultyCard));
        UnityEngine.Object[] R_Staff_FacultyCards = Resources.LoadAll("Cards/FacultyCards/StaffFaculty", typeof(FacultyCard));

        // Loading Buiding cards.
        UnityEngine.Object[] R_BuildingCards = Resources.LoadAll("Cards/BuildingCards", typeof(BuildingCard));

        
        List<UnityEngine.Object[]> R_cards = new List<UnityEngine.Object[]>();
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
        foreach (UnityEngine.Object[] R_card in R_cards)
        {
            foreach (UnityEngine.Object R_cardObj in R_card)
            {
                var card = (Card)R_cardObj;
                if(!cardDict.ContainsKey(card.name)){
                cardDict.Add(card.name, card);
            }
            }
        }




        currentDeckPath = Application.dataPath + "/Data/DeckData.json";
        if(!File.Exists(currentDeckPath)){
            File.WriteAllText(currentDeckPath, "");
        }

        DeckData = new DataSave();
        DeckData.decks = new List<DeckSave>();
        addDeck(false);
        loadDataFromJson();
    }

    public List<Card> getAllCards(){
        List<Card> cards = new List<Card>();
        foreach(KeyValuePair<string, Card> entry in cardDict){
            cards.Add(entry.Value);
        }
        return cards;
    }
    
    public Card getCard(string name){
        if(cardDict.ContainsKey(name)){
            return cardDict[name];
        }
        return null;
    }

    public void saveDataToJson(){
        string json = JsonUtility.ToJson(DeckData);
        File.WriteAllText(currentDeckPath, json);
    }

    public void loadDataFromJson(){
        string json = File.ReadAllText(currentDeckPath);
        JsonUtility.FromJsonOverwrite(json, DeckData);
    }

    public void addDeck(bool save = true){
        DeckSave newDeck = new DeckSave();
        newDeck.cards = new List<string>();
        DeckData.decks.Add(newDeck);
        if(save){
            saveDataToJson();
        }
    }

    public void setCurrentDeck(int deck){
        if(deck < DeckData.decks.Count){
            DeckData.currentDeck = deck;
            saveDataToJson();
        }
    }

    public void removeDeck(int deckIndex){
        if(deckIndex < DeckData.decks.Count){
            DeckData.decks.RemoveAt(deckIndex);
            saveDataToJson();
        }
    }

    public void addCardToDeck(string card){
        if(DeckData.decks.Count > 0){
            DeckData.decks[DeckData.currentDeck].cards.Add(card);
            saveDataToJson();
        }
    }


    public void removeCardFromDeck(string card){
        if(DeckData.decks.Count > 0){
            DeckData.decks[DeckData.currentDeck].cards.Remove(card);
            saveDataToJson();
        }
    }

    public List<Card> getCurrentDeck(){
        List<Card> cards = new List<Card>();
        foreach(string card in DeckData.decks[DeckData.currentDeck].cards){
            cards.Add(getCard(card));
        }
        return cards;
    }

    public GameObject getCardPrefab(Card.Type type){
        switch(type){
            case Card.Type.Building:
                return buildingCardDisplayPrefab;
            case Card.Type.Faculty:
                return facultyCardDisplayPrefab;
            case Card.Type.Student:
                return studentCardDisplayPrefab;
            default:
                return null;
        }
    }
}
