using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCoordinator : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        needsTargetting = true;
    }

    // Rally - Grant a target student this ability : act again.
    public override int PerformEffect(GameData data){
        StudentCardDisplay student;
        if (data.target[0].gameObject.TryGetComponent(out student)){
            data.target[0].ReactivateCard();
            Debug.Log("ECoordinator worked");
        }
        else{
            Debug.Log("Error with Ecoordinator effect");
        }
        return 0;
    }
}
