using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JazzBand : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }
    //Flip a coin. If heads, grant all friendly students 1 duration. If tails, reduce this card's duration by 1.
    public override int PerformEffect(GameData data)
    {
        //GameObject go = data.target[0].gameObject;
        //BuildingCardDisplay target;

        //int effectValue = 4 + data.self.GetEffectValueModifier();

        var friendly = data.friendlyStudents;
        int luckModifier = GetLuckModifierValue(data.friendlyPlayer, data.self);

        if (FlipCoin(luckModifier) == 1)
        {
            foreach (var x in friendly)
            {
                x.ChangeDurationBy(1);
            }
            Debug.Log("Jazz band hit heads");
        }
        else
        {
            data.self.gameObject.GetComponent<StudentCardDisplay>().ChangeDurationBy(-1);
            Debug.Log("Jazz band hit tails");
        }
        return 0;
    }
}