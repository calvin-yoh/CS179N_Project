using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : Player
{
    public bool isDrawPhase = true;
    public bool isPlaceCardsPhase = false;
    public bool isActivateEffectPhase = false;
    public bool isEndTurnPhase = false;

    // Start is called before the first frame update
    void Start()
    {  
        isAI = true;
        isDrawPhase = true;
        isPlaceCardsPhase = false;
        isActivateEffectPhase = false;
        isEndTurnPhase = false;

        // hand = new List<Card>(20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBools()
    {
        isDrawPhase = true;
        isPlaceCardsPhase = false;
        isActivateEffectPhase = false;
        isEndTurnPhase = false;
        hasPlayedFacultyCard = false;
        hasPlayedStudentCard = false;
    }


    public IEnumerator PlayAITurn()
    {
        ResetBools();
        StartCoroutine(DrawPhase());
        yield return new WaitUntil(() => isPlaceCardsPhase);
        StartCoroutine(PlaceCardsPhase());
        yield return new WaitUntil(() => isActivateEffectPhase);
        StartCoroutine(ActivateEffectPhase());
        yield return new WaitUntil(() => isEndTurnPhase);

        yield return new WaitForSeconds(1f);
        Debug.Log("End Turn");
        EndTurn();
    }

    public IEnumerator DrawPhase()
    {
        Debug.Log("Drawing a card");
        DrawCard();
        yield return new WaitForSeconds(2f);
        Debug.Log("Drew a card");
        Debug.Log("Moving to next phase");
        isPlaceCardsPhase=true;
    }

    public IEnumerator PlaceCardsPhase()
    {
        Debug.Log("Placing card code goes here");
        Card placeCard = GetRandomCardInHand();
        int index = 0;
        while (field.CheckIfOccupied(index, placeCard.type)){           // Get next available index on the field
            index++;
            if (index >= 3 && placeCard.type == Card.Type.Faculty){
                Debug.Log("Faculty slots are full");
                isActivateEffectPhase = true;
                yield break;
            }
            else if (index >= 7 && placeCard.type == Card.Type.Student){
                Debug.Log("Student slots are full");
                isActivateEffectPhase = true;
                yield break;
            }
        }
        Debug.Log("Placing " + placeCard.name + " at index " + index);
        base.PlaceCard(index, placeCard);
        yield return new WaitForSeconds(1f);

        Debug.Log("Moving to next phase");
        isActivateEffectPhase = true;
    }

    public IEnumerator ActivateEffectPhase()
    {
        Debug.Log("Activating effect code goes here");
        yield return new WaitForSeconds(3f);
        Debug.Log("Ending turn");
        isEndTurnPhase = true;
        yield return null;
    }

    private Card GetRandomCardInHand(){
        List<CardDisplay> cardHand = hand.getHand();
        int randIndex = Random.Range(0, cardHand.Count);
        Card returnCard = cardHand[randIndex].card;
        return returnCard;
    }
}
