using System.Linq.Expressions;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Staff Faculty 
public class AcademicAdvisor : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Academic advisor - Reactivate all your student cards. // same thing as reactivate 
    public override int PerformEffect(GameData data)
    {
        foreach(var student in data.friendlyStudents)
        {
            student.ReactivateCard();
            Debug.Log("Academic advisor worked");
        }
        return 0;
    }
}
