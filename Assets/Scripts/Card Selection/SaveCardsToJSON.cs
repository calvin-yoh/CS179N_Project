using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CardDeck{
    public List<string> cards = new List<string>();
}

public class SaveCardsToJSON : MonoBehaviour
{
    public void saveCards(){
        CardDeck deck = new CardDeck();

        for(int i = 0; i < transform.childCount; i++){
            var temp = transform.GetChild(i).gameObject;
            string json = "";

            switch(temp.name){
                case "UIStudentCard(Clone)(Clone)":
                    json = JsonUtility.ToJson(temp.GetComponent<StudentCardDisplay>().card, true);
                    break;  
                case "UIBuildingCard(Clone)(Clone)":
                    json = JsonUtility.ToJson(temp.GetComponent<BuildingCardDisplay>().card, true);
                    break;
                case "UIFacultyCard(Clone)(Clone)":
                    json = JsonUtility.ToJson(temp.GetComponent<FacultyCardDisplay>().card, true);
                    break;
            }
            deck.cards.Add(json);
        }
        var jsonData = JsonUtility.ToJson(deck);
        File.WriteAllText(Application.dataPath + "/deckData.json", jsonData);
    }
}
