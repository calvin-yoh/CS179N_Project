using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SculptingLab : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }

    private void OnEnable()
    {
        Player oppPlayer = GameManager.Instance.GetOpposingPlayer();
        EventsManager em = oppPlayer.GetEventsManager();
        em.OnCardPlayedFromHand += CardPassive;
    }

    private void OnDisable()
    {
        Player oppPlayer = GameManager.Instance.GetOpposingPlayer();
        EventsManager em = oppPlayer.GetEventsManager();
        em.OnCardPlayedFromHand -= CardPassive;
    }

    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    //The opponent's student cards have -1 duration when played.
    public override void CardPassive(CardDisplay card)
    {
        StudentCardDisplay scd = card.GetComponent<StudentCardDisplay>();
        if (scd != null)
        {
            Debug.Log("ScupltingLab building increased dur");
            scd.ChangeDurationBy(-1);
        }
    }
}