using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Staff student
public class Librarian : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }

    // Shush - Reduce a target student's effect value by {2} for 1 turn.
    public override int PerformEffect(GameData data){
        StudentCardDisplay target;
        int effectValue = 2 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();
        if (data.target[0].gameObject.TryGetComponent(out target)){
            target.SetEffectValueModifier(target.GetEffectValueModifier() - effectValue);
            Debug.Log("Librarian worked");
        }
        else{
            Debug.Log("Error with Librarian effect");
        }
        return 0;
    }
}
