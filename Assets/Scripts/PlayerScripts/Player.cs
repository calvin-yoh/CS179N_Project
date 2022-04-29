using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numStartingCards = 5;

    // private bool canPlaceStudent = true;
    // private bool canPlaceFaculty = true;
    public HandLayout hand;
    public List<Card> openDeck;     // The deck that is loaded, can view in the inspector
    private Stack<Card> deck;       // The deck used in game that is represented with a stack

    public GameObject buildingCardDisplay;
    public GameObject studentCardDisplay;
    public GameObject facultyCardDisplay;

    public void StartTurn(){
        // canPlaceFaculty = true;
        // canPlaceStudent = true;
        DrawCard();
    }

    public void DrawCard(){
        // hand.Add(deck.Pop());
        Card newCard = deck.Pop();
        // CardDisplay newDisplay = new CardDisplay(newCard);

        GameObject gameob;

        switch (newCard.type)
        {
            case Card.Type.Building:
                gameob = Instantiate(buildingCardDisplay, gameObject.transform);
                break;
            case Card.Type.Student:
                gameob = Instantiate(studentCardDisplay, gameObject.transform);
                break;
            case Card.Type.Faculty:
                gameob = Instantiate(facultyCardDisplay, gameObject.transform);
                break;
            default:
                gameob = null;
                Debug.Log("ERROR");
                break;

        }

        if (gameob == null)
            return;

        CardDisplay cd = gameob.GetComponent<CardDisplay>();

        cd.card = newCard;
        cd.inHand = true;
        cd.SetUpInformation();
        cd.ResetCard();
        cd.DisplayInformation();

        hand.AddCard(cd);
        // Debug.Log(this.name + " has " + hand.Count + " cards");
    }

    public void EndTurn(){
        GameManager.Instance.SwitchPlayers();
    }

    void Start(){
        deck = new Stack<Card>();
        // hand = new List<Card>(20);
        for (int i=0; i < openDeck.Count; i++){
            deck.Push(openDeck[i]);
        }

        for (int i=0; i < numStartingCards; i++){
            DrawCard();
        }
    }
}
