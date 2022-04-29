using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLayout : MonoBehaviour
{
    private List<CardDisplay> hand; // List that holds all my ten cards
    public Transform start;  //Location where to start adding my cards
    //  public Transform HandDeck; //The hand panel reference
    public float howManyAdded; // How many cards I added so far
    public float gapFromOneItemToTheNextOne; //the gap I need between each card

    void Awake()
    {
        hand = new List<CardDisplay>();
        howManyAdded = 0.0f;
        //  gapFromOneItemToTheNextOne = 1.0f;
        FitCards();
    }

    public void AddCard(CardDisplay card)
    {
        hand.Add(card);
        FitCards();
        howManyAdded++;
        start.transform.position -= new Vector3(0.5f, 0, 0);
        card.transform.SetParent(this.gameObject.transform); //Setting my card parent to be the Hand Panel
    }

    public void RemoveCard(Card card)
    {
        // foreach (CardDisplay cd in hand){
        //     if (cd.card == card){
        //         start.transform.position += new Vector3(0.5f, 0, 0);
        //         hand.Remove(cd);
        //     }
        // }
        for (int i = 0; i < hand.Count; i++)
        {
            CardDisplay cd = hand[i];
            if (cd.card == card)
            {
                hand.RemoveAt(i);
                start.transform.position += new Vector3(0.5f, 0, 0);
                Destroy(cd.gameObject);
                howManyAdded--;
                FitCards();
                return;
            }
        }
    }

    public List<CardDisplay> getHand()
    {
        return hand;
    }

    public void FitCards()
    {

        //  if (hand.Count == 0) //if list is null, stop function
        //      return;
        float totalTwist = 20;
        // 20f for example, try various values
        int numberOfCards = hand.Count; //... get this from your List or array
        float twistPerCard = totalTwist / numberOfCards;
        float startTwist = totalTwist / 2f;

        for (int i = 0; i < hand.Count; i++)
        {
            GameObject currCard = hand[i].gameObject; //Reference to first image in my list
            currCard.GetComponentInChildren<Canvas>().sortingOrder = i;
            currCard.transform.position = start.position; //relocating my card to the Start Position
            currCard.transform.position += new Vector3((i * gapFromOneItemToTheNextOne), i * 0.1f, 0); // Moving my card 1f to the right
            float twistForThisCard = startTwist - (i * twistPerCard);
            currCard.transform.rotation = Quaternion.Euler(90f, 0f, twistForThisCard);

            if (i == 0 || i == hand.Count - 1)
            {
                float scalingFactor = 0.01f;
                // that should be roughly one-tenth the height of one
                // of your cards, just experiment until it works well
                float nudgeThisCard = Mathf.Abs(twistForThisCard);
                nudgeThisCard *= scalingFactor;
                currCard.transform.Translate(0f, -nudgeThisCard, 0f);
            }
        }
        //  hand.RemoveAt (0);
    }
}
