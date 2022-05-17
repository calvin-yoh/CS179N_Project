using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custodian : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
    }

    // Clean - Heal all friendly buildings by {2}.
    public override int PerformEffect(GameData data){
        BuildingCardDisplay student;
        if (data.target.gameObject.TryGetComponent(out student)){
            data.target.ReactivateCard();
            Debug.Log("Custodian worked");
        }
        else{
            Debug.Log("Error with Custodian effect");
            return -1;
        }
        return 0;
    }
}
