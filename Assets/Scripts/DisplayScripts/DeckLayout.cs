using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckLayout : MonoBehaviour
{
    public List<Card> openDeck;     // The deck that is loaded, can view in the inspector
    public GameObject buildingCardDisplay;
    public GameObject studentCardDisplay;
    public GameObject facultyCardDisplay;

    private Stack<CardDisplay> deck;
    private int number;

    public void SetUpDeck(){
        number = gameObject.GetComponentInParent<Player>().number;

        ShuffleDeck();
        GameObject gameob;
        deck = new Stack<CardDisplay>();

        float zOffset = 0;
        foreach (Card newCard in openDeck){
            switch (newCard.type)
            {
                case Card.Type.Building:
                    gameob = Instantiate(buildingCardDisplay, gameObject.transform.position + new Vector3(0, 0, zOffset), gameObject.transform.rotation);
                    break;
                case Card.Type.Student:
                    gameob = Instantiate(studentCardDisplay, gameObject.transform.position + new Vector3(0, 0, zOffset), gameObject.transform.rotation);
                    break;
                case Card.Type.Faculty:
                    gameob = Instantiate(facultyCardDisplay, gameObject.transform.position + new Vector3(0, 0, zOffset), gameObject.transform.rotation);
                    break;
                default:
                    gameob = null;
                    Debug.Log("ERROR");
                    break;
            }
            if (gameob != null){
                gameob.transform.parent = this.gameObject.transform;
            }
            zOffset += 0.1f;
            CardDisplay cd = gameob.GetComponent<CardDisplay>();
            cd.card = newCard;
            cd.playerNumber = number;
            cd.SetUpInformation();
            cd.ReactivateCard();
            deck.Push(cd);
        }
    }

    public void ShuffleDeck(){      // Only shuffles at the beginning, does not work for midgame
        int index;
        for (int i=0; i < openDeck.Count-1; i++){
            index = Random.Range(i+1, openDeck.Count);
            Card tmp = openDeck[index];
            openDeck[index] = openDeck[i];
            openDeck[i] = tmp;
        }
    }

    public CardDisplay GetTop(){
        return deck.Pop();
    }
}
