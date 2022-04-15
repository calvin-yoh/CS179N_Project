using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numStartingCards = 5;

    private bool canPlaceStudent = true;
    private bool canPlaceFaculty = true;
    private List<Card> hand;
    public List<Card> openDeck;
    private Stack<Card> deck;

    public void StartTurn(){
        canPlaceFaculty = true;
        canPlaceStudent = true;
        DrawCard();
    }

    public void DrawCard(){
        hand.Add(deck.Pop());
        Debug.Log(this.name + " has " + hand.Count + " cards");
    }

    public void PlaceCard(Card card){

    }

    public void EndTurn(){
        GameManager.Instance.SwitchPlayers();
    }

    void Start(){
        deck = new Stack<Card>();
        hand = new List<Card>(20);
        for (int i=0; i < openDeck.Count; i++){
            deck.Push(openDeck[i]);
        }

        for (int i=0; i < numStartingCards; i++){
            DrawCard();
        }
    }
}
