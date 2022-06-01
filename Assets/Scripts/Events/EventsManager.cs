using UnityEngine;
using System.Collections;

public class EventsManager : MonoBehaviour
{
    public delegate void CardPlayedFromHand(CardDisplay card);
    public static event CardPlayedFromHand OnCardPlayedFromHand;

    public static void CallOnCardPlayedFromHand(CardDisplay card)
    {
        if (OnCardPlayedFromHand != null)
        {
            OnCardPlayedFromHand(card);
        }
    }
}
