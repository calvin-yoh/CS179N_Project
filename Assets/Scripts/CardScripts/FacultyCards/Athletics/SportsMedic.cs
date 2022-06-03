using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportsMedic : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 1;
    }

    //Restore one athlete's (full) duration points but disables it for one turn.
    public override int PerformEffect(GameData data)
    {
        CardDisplay target = data.target[0];
        
        StudentCardDisplay temp;

        if(target.TryGetComponent(out temp))
        {
            if(temp.GetCardMajor() == Card.Major.Athletics)
            {
                temp.SetDuration(temp.card.duration);
                temp.DistractCard();
            }
            else
            {
                Debug.Log("Sports medic says not an athlete");
                gameObject.GetComponent<CardDisplay>().ReactivateCard();
                return -1;
            }
        }
        return 0;
    }
}
