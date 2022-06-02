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
        numTargets = 0;
    }

    // Chancellor - Every 3 turns choose one of your opponents card to remove from play
    public override int PerformEffect(GameData data)
    {
        
        // GameObject go = data.target[0].gameObject;
        // CardDisplay target;
        // var turnCounter = 1;


        // if(go.TryGetComponent(out target)){
        //     target.RemoveCardFromPlay();
        //     if(data)
        //     Debug.Log("Chancellor expelled a student");

        // } else {
        //     Debug.Log("Error when Chancellor tries to expel a student");
        // }
    
        return 0;
    }
}
