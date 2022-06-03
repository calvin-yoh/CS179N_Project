using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numStartingCards = 5;

    public AudioSource drawSound;
    public AudioSource placeCardSound;

    [SerializeField] protected HandLayout hand;
    [SerializeField] protected FieldLayout field;
    [SerializeField] protected DeckLayout deck;
    [SerializeField] protected EventsManager ev;

    public bool isAI = false;
    public int number;
    public int numStudentCardsCanPlace;
    public int numFacultyCardsCanPlace;
    
    private LuckModifier luckModifier = new LuckModifier();

    void Start(){
        // hand = new List<Card>(20);
    }

    public void SetUpDeck(){

        if (!isAI)
        {
            // deck.SetCustomDeck();
        }
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
        numStudentCardsCanPlace = 1;
        numFacultyCardsCanPlace = 1;
        field.ReactivateCards();
        DrawCard();
        ActivateBuildingEffects();
    }

    public void DrawCard(){
        CardDisplay cd = deck.GetTop();
        if (cd != null){
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
        else{       // Player is out of cards, take fatigue damage
            TakeFatigueDamage();
        }
    }

    //Dupe to prevent breaking current functionality
    public void PlaceBuilding(int index, Card newCard)
    {
        field.ActivateCard(index, newCard, number);
    }

    public void ActivateBuildingEffects(){
        foreach (BuildingCardDisplay b in field.GetActiveBuildingCards()){
            GameData gd = GameManager.Instance.GetGameData(b);
            b.ActivateEffect(gd);
        }
    }

    public CardDisplay PlaceCard(int index, CardDisplay newCardDisplay){
        Card newCard = newCardDisplay.card;
        Card.Type type = newCard.type;
        switch (type){
            case Card.Type.Student:
                if (numStudentCardsCanPlace == 0){  // Already played student card, don't place card down
                    return null;
                }
                else{
                    numStudentCardsCanPlace--;
                }
                break;
            case Card.Type.Faculty:
                if (numFacultyCardsCanPlace == 0){  // Already played faculty card, don't place card down
                    return null;
                }
                else{
                    numFacultyCardsCanPlace--;
                }
                break;
            case Card.Type.Building:
                return field.ActivateCard(index, newCardDisplay, number);;
            default:
                break;
        }
        CardDisplay c = field.ActivateCard(index, newCardDisplay, number);
        ev.CallOnCardPlayedFromHand(c);
        hand.RemoveCard(newCardDisplay);

        //place card sound effect
        placeCardSound.Play();
        return c;
    }

    public void ChangeNumStudentsCanPlace(int change){
        numStudentCardsCanPlace += change;
    }

    public void ChangeNumFacultyCanPlace(int change){
        numFacultyCardsCanPlace += change;
    }

    public void TakeFatigueDamage(){
        foreach (BuildingCardDisplay b in field.GetActiveBuildingCards()){
            b.DamageBuilding(5);
        }
    }

    public void EndTurn(){
        field.ReduceStudentCardDurations();
        field.ReduceEffectModifiers();
        GameManager.Instance.SwitchPlayers();
        field.ResetBuildingBools();
        field.IncreaseCardsTurnCounts();
    }
}
