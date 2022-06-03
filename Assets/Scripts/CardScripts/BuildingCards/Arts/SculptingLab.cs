using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SculptingLab : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
    }

    //The opponent's student cards have -1 duration when played.
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