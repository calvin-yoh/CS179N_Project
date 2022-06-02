using UnityEngine;
using System.Collections;

public class EventsManager : MonoBehaviour
{
    public delegate void CardPlayedFromHand(CardDisplay card);
    public event CardPlayedFromHand OnCardPlayedFromHand;

    public void CallOnCardPlayedFromHand(CardDisplay card)
    {
        if (OnCardPlayedFromHand != null)
        {
            OnCardPlayedFromHand(card);
        }
    }
}
