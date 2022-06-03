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
        targetTeam = TargetTeam.Friendly;
        numTargets = 1;
    }

    // Academic advisor - remove random card from enemy hands
    public override int PerformEffect(GameData data)
    {
        
        if(data.self.turnsInPlay %2 == 0){
            
            //foreach()
            
            Debug.Log("Admissions office removed card from enemy hand");
        } 
        else 
        {
            Debug.Log("Error when Admissions office needs to wait longer");
        }


        
    
        return 0;
    }
}
