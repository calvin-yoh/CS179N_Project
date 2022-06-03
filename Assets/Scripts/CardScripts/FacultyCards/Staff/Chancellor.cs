using System.Linq.Expressions;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Staff Faculty 
public class Chancellor : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }

    // Chancellor - Remove a student from play. Disable this card for 1 turn.
    public override int PerformEffect(GameData data)
    {
        CardDisplay target = data.target[0];
        GameObject go = target.gameObject;

        StudentCardDisplay temp;

        if(go.TryGetComponent(out temp))
        {
            temp.SetDuration(0);
            Debug.Log("Chancellor expelled a student");
            gameObject.GetComponent<CardDisplay>().DistractCard();
        } 
        else 
        {
            Debug.Log("Error when Chancellor tries to expel a student");
        }
        return 0;
    }
}
