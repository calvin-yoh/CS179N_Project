using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAndFieldCoach : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 2;
    }

    // // Target 2 of your opponents student cards, and reduce their duration by 1.
    public override int PerformEffect(GameData data)
    {
        List<CardDisplay> target = data.target;

        foreach(var t in target)
        {
            StudentCardDisplay temp;

            if(t.TryGetComponent(out temp))
            {
                temp.ChangeDurationBy(-1);
                Debug.Log("TrackAndFieldCoach reduced duration");
            }
            else
            {
                Debug.Log("Targeted wrong thing");
                return -1;
            } 
        }
        return 0;
    }
    
}
