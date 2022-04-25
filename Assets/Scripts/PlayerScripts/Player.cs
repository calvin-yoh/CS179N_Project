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
    public GameObject display;

    public void StartTurn(){
        // canPlaceFaculty = true;
        // canPlaceStudent = true;
        DrawCard();
    }

    public void DrawCard(){
        // hand.Add(deck.Pop());
        Card newCard = deck.Pop();
        // CardDisplay newDisplay = new CardDisplay(newCard);
        var gameob = Instantiate(display, gameObject.transform);
        gameob.GetComponent<CardDisplay>().card = newCard;
        hand.AddCard(gameob.GetComponent<CardDisplay>());
        // Debug.Log(this.name + " has " + hand.Count + " cards");
    }

    public void PlaceCard(Card card){

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
