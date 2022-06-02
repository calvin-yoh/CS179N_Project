using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numStartingCards = 5;

    public AudioSource drawSound;
    public AudioSource placeCardSound;

    // private bool canPlaceStudent = true;
    // private bool canPlaceFaculty = true;
    [SerializeField] protected HandLayout hand;
    [SerializeField] protected FieldLayout field;
    [SerializeField] protected DeckLayout deck;
    [SerializeField] protected EventsManager ev;

    public bool isAI = false;
    public int number;
    protected bool hasPlayedStudentCard;
    protected bool hasPlayedFacultyCard;
    
    private LuckModifier luckModifier = new LuckModifier();

    void Start(){
        // hand = new List<Card>(20);
    }

    public void SetUpDeck(){
        deck.SetUpDeck();
    }

    #region Getters/Setters

    public FieldLayout GetField(){
        return field;
    }

    public DeckLayout GetDeck()
    { 
        return deck;
    }

    public HandLayout GetHand()
    {
        return hand;
    }

    public LuckModifier GetLuckModifier()
    {
        return luckModifier;
    }

    public EventsManager GetEventsManager(){
        return ev;
    }

    #endregion

    public void StartTurn(){
        hasPlayedFacultyCard = false;
        hasPlayedStudentCard = false;
        field.ReactivateCards();
        DrawCard();
    }

    public void DrawCard(){
        CardDisplay cd = deck.GetTop();
        cd.inHand = true;
        cd.inDeck = false;
        cd.SetUpInformation();
        cd.ReactivateCard();
        cd.DisplayInformation();

        hand.AddCard(cd);
        // Debug.Log(this.name + " has " + hand.Count + " cards");

        //sound effect for draw
        drawSound.Play();
    }

    //Dupe to prevent breaking current functionality
    public void PlaceBuilding(int index, Card newCard)
    {
        field.ActivateCard(index, newCard, number);
    }

    public void PlaceCard(int index, CardDisplay newCardDisplay){
        Card newCard = newCardDisplay.card;
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
            case Card.Type.Building:
                field.ActivateCard(index, newCardDisplay, number);
                return;
            default:
                break;
        }
        CardDisplay c = field.ActivateCard(index, newCardDisplay, number);
        ev.CallOnCardPlayedFromHand(c);
        hand.RemoveCard(newCardDisplay);

        //place card sound effect
        placeCardSound.Play();
    }

    public void EndTurn(){
        field.ReduceStudentCardDurations();
        field.ReduceEffectModifiers();
        GameManager.Instance.SwitchPlayers();
    }
}
