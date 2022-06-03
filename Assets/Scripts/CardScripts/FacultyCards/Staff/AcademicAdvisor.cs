using System.Linq.Expressions;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Staff Faculty 
public class AcademicAdvisor : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 1;
    }

    // Academic advisor - Choose one of your students cards to prevent it from being disabled for 1 turn // same thing as reactivate 
    public override int PerformEffect(GameData data)
    {
        
        StudentCardDisplay student;
        if (data.target[0].gameObject.TryGetComponent(out student))
        {
            data.target[0].ReactivateCard();
            Debug.Log("Academic advisor worked");
        }
        else
        {
            Debug.Log("Error with Academic advisor effect");
        }

        
    
        return 0;
    }
}
