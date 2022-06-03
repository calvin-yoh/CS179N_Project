using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theater : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    private void OnEnable()
    {
        Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand += CardPassive;
        em.OnCardRemovedFromField += CardPassive;
    }

    private void OnDisable()
    {
        Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand -= CardPassive;
        em.OnCardRemovedFromField -= CardPassive;
    }

    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    //If any friendly Actor card is in play, this building cannot be attacked.
    public override void CardPassive(CardDisplay card)
    {
        StudentCardDisplay scd = card.GetComponent<StudentCardDisplay>();
        if (scd != null)
        {
            Debug.Log("ConcertHall building increased dur");
            scd.ChangeDurationBy(1);
        }
    }
}