using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numStartingCards = 5;

    // private bool canPlaceStudent = true;
    // private bool canPlaceFaculty = true;
    [SerializeField] private HandLayout hand;
    [SerializeField] private FieldLayout field;
    public List<Card> openDeck;     // The deck that is loaded, can view in the inspector
    protected Stack<Card> deck;       // The deck used in game that is represented with a stack

    public GameObject buildingCardDisplay;
    public GameObject studentCardDisplay;
    public GameObject facultyCardDisplay;

    public bool isAI = false;
    public int number;
    private bool hasPlayedStudentCard;
    private bool hasPlayedFacultyCard;

    void Start(){
        // hand = new List<Card>(20);
    }

    public FieldLayout GetField(){
        return field;
    }

    public bool HasPlayedStudentCard(){
        return hasPlayedStudentCard;
    }

    public bool HasPlayedFacultyCard(){
        return hasPlayedFacultyCard;
    }

    public void SetUpDeck(){
        ShuffleDeck();
        deck = new Stack<Card>();
        for (int i=0; i < openDeck.Count; i++){
            deck.Push(openDeck[i]);
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

    public void StartTurn(){
        hasPlayedFacultyCard = false;
        hasPlayedStudentCard = false;
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
        cd.playerNumber = number;
        cd.inHand = true;
        cd.SetUpInformation();
        cd.ResetCard();
        cd.DisplayInformation();

        hand.AddCard(cd);
        // Debug.Log(this.name + " has " + hand.Count + " cards");
    }

    public void PlaceCard(int index, Card newCard){
        Card.Type type = newCard.type;
        switch (type){
            case Card.Type.Student:
                if (hasPlayedStudentCard){  // Already played student card, don't place card down
                    return;
                }
                else{
                    hasPlayedStudentCard = true;
                }
                break;
            case Card.Type.Faculty:
                if (hasPlayedFacultyCard){  // Already played faculty card, don't place card down
                    return;
                }
                else{
                    hasPlayedFacultyCard = true;
                }
                break;
            default:
                break;
        }
        field.ActivateCard(index, newCard);
        hand.RemoveCard(newCard);
    }

    public void EndTurn(){
        GameManager.Instance.SwitchPlayers();
    }

}
