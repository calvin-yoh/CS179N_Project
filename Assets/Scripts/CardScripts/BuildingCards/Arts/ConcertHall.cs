using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertHall : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    private void OnEnable()
    {
        // Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        // EventsManager em = currPlayer.GetEventsManager();
        // em.OnCardPlayedFromHand += CardPlayedFromHandPassive;    
    }

    private void OnDisable()
    {
        Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand -= CardPlayedFromHandPassive;
    }

    //Your student cards have +1 duration when played.
    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    public override void CardPlayedFromHandPassive(CardDisplay card)
    {
        StudentCardDisplay scd = card.GetComponent<StudentCardDisplay>();
        if (scd != null)
        {
            if (scd.playerNumber == GameManager.Instance.GetCurrentPlayer().number)
            {
                Debug.Log("ConcertHall building increased dur");
                scd.ChangeDurationBy(1);
            }
        }
    }
}