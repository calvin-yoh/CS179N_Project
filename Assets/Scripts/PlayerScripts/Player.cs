using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int numStartingCards = 5;

    // private bool canPlaceStudent = true;
    // private bool canPlaceFaculty = true;
    [SerializeField] protected HandLayout hand;
    [SerializeField] protected FieldLayout field;
    [SerializeField] protected DeckLayout deck;

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
        cd.SetUpInformation();
        cd.ReactivateCard();
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
            case Card.Type.Building:
                field.ActivateCard(index, newCard, number);
                return;
            default:
                break;
        }
        field.ActivateCard(index, newCard, number);
        hand.RemoveCard(newCard);
    }

    public void EndTurn(){
        field.ReduceStudentCardDurations();
        field.ReduceEffectModifiers();
        GameManager.Instance.SwitchPlayers();
    }
}
