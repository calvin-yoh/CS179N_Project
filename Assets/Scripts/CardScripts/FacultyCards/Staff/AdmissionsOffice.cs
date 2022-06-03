using System.Linq.Expressions;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Staff Faculty 
public class AdmissionsOffice : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }

    //Discard a random card from your opponent's hand. Disable this card for 1 turn.
    public override int PerformEffect(GameData data)
    {
        var hand =  data.enemyHand;
        hand.RemoveRandomCard();
        gameObject.GetComponent<CardDisplay>().DistractCard();
        return 0;
    }
}
