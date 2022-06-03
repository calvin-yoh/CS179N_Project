using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDevelopers : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }

    // Script - Distract a target enemy student for 1 turn.
    public override int PerformEffect(GameData data)
    {
        if (data.target[0].GetCardType() != Card.Type.Student)
        {
            return -1;
        }

        StudentCardDisplay student;
        if (data.target[0].gameObject.TryGetComponent(out student))
        {
            data.target[0].DistractCard();
            Debug.Log("GameDevelopers worked");
        }
        else
        {
            Debug.Log("Error with GameDevelopers effect");
        }
        return 0;
    }
}
