using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBatter : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }

    // Report - Distract a target enemy student for 1 turn.
    public override int PerformEffect(GameData data)
    {
        if(data.target[0].GetCardType() != Card.Type.Student)
        {
            return -1;
        }
        
        StudentCardDisplay student;
        if (data.target[0].gameObject.TryGetComponent(out student))
        {
            data.target[0].DistractCard();
            Debug.Log("BaseballBatter worked");
        }
        else
        {
            Debug.Log("Error with BaseballBatter effect");
        }
        return 0;
    }
}
