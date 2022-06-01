using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Flip a coin. If heads, distract all enemy student cards for 1 turn. If tails, reduce all friendly students duration by 1.
public class Cast : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }

    public override int PerformEffect(GameData data)
    {
        int luckModifier = GetLuckModifierValue(data.friendlyPlayer, data.self);
        if (FlipCoin(luckModifier) == 1)
        {
            foreach (StudentCardDisplay student in data.enemyStudents)
            {
                //Distrct all enemy students
                student.DistractCard();
                Debug.Log("Distracting " + student.GetCardName() + " for 1 turn");
            }
        }
        else
        {
            foreach (StudentCardDisplay student in data.friendlyStudents)
            {
                //Reduce duration of all friendly students by 1
                student.ChangeDurationBy(-1);
                Debug.Log("Reducing duration of " + student.GetCardName() + " by 1");
            }
            Debug.Log("Cast hit tails");
        }

        return 0;
    }
}
