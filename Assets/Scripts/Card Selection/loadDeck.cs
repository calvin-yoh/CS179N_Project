using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class loadDeck : MonoBehaviour
{

    public GameObject BuildingCardDisplayPrefab;
    public GameObject StudentCardDisplayPrefab;
    public GameObject FacultyCardDisplayPrefab;
    // Start is called before the first frame update
    void Start()
    {
        string deckData = File.ReadAllText(Application.dataPath + "/deckData.json");   
        CardDeck deck = JsonUtility.FromJson<CardDeck>(deckData);
        List<Card> cards = new List<Card>();
        foreach(string s_card in deck.cards){
            Card card = ScriptableObject.CreateInstance<Card>();
            JsonUtility.FromJsonOverwrite(s_card, card);
            cards.Add(card);
            switch(card.type){
                case Card.Type.Student:
                    var go = Instantiate(StudentCardDisplayPrefab, transform.position, transform.rotation);
                    go.GetComponent<StudentCardDisplay>().card = card;
                    go.GetComponent<StudentCardDisplay>().SetUpInformation();
                    go.GetComponent<StudentCardDisplay>().DisplayInformation();

                    go.transform.SetParent(this.transform);
                    break;
                case Card.Type.Faculty:
                    var go1 = Instantiate(FacultyCardDisplayPrefab, transform.position, transform.rotation);
                    go1.GetComponent<StudentCardDisplay>().card = card;
                    go1.GetComponent<StudentCardDisplay>().SetUpInformation();
                    go1.GetComponent<StudentCardDisplay>().DisplayInformation();

                    go1.transform.SetParent(this.transform);
                    break;
                case Card.Type.Building:
                    var go2 = Instantiate(BuildingCardDisplayPrefab, transform.position, transform.rotation);
                    go2.GetComponent<StudentCardDisplay>().card = card;
                    go2.GetComponent<StudentCardDisplay>().SetUpInformation();
                    go2.GetComponent<StudentCardDisplay>().DisplayInformation();

                    go2.transform.SetParent(this.transform);
                    break;
            }
        }
    }
}
