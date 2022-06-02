using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gym : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    private void OnEnable()
    {
        Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand -= CardPlayedFromHandPassive;    }

    private void OnDisable()
    {
        Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand -= CardPlayedFromHandPassive;    }

    // All your Athletics cards gain +1 duration when played.
    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    public override void CardPlayedFromHandPassive(CardDisplay card)
    {
        StudentCardDisplay scd;
        if (card.TryGetComponent(out scd))
        {
            if (scd.GetCardMajor() == Card.Major.Athletics){
                Debug.Log("Gym building increased dur");
                scd.ChangeDurationBy(1);
            }
        }
    }
}
