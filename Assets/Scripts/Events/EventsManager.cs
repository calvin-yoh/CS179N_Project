using UnityEngine;
using System.Collections;

public class EventsManager : MonoBehaviour
{
    public delegate void CardPlayedFromHand(CardDisplay card);
    public event CardPlayedFromHand OnCardPlayedFromHand;

    public delegate void CardRemovedFromField(CardDisplay card);
    public event CardRemovedFromField OnCardRemovedFromField;

    public void CallOnCardPlayedFromHand(CardDisplay card)
    {
        if (OnCardPlayedFromHand != null)
        {
            OnCardPlayedFromHand(card);
        }
    }

    public void CallOnCardRemovedFromField(CardDisplay card)
    {
        if (OnCardRemovedFromField != null)
        {
            OnCardRemovedFromField(card);
        }
    }    
}
