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

        deck = new Stack<Card>();
        // hand = new List<Card>(20);
        for (int i = 0; i < openDeck.Count; i++)
        {
            deck.Push(openDeck[i]);
        }

        for (int i = 0; i < numStartingCards; i++)
        {
            DrawCard();
        }
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
    }


    public IEnumerator PlayAITurn()
    {
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
        yield return new WaitForSeconds(3f);
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
}
