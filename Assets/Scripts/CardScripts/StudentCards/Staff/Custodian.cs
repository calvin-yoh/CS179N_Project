using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custodian : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Clean - Heal all friendly buildings by {2}.
    public override int PerformEffect(GameData data){
        foreach (BuildingCardDisplay building in data.friendlyBuildings){
            building.HealBuilding(2 + data.self.GetEffectValueModifier());
        }
        return 0;
    }
}
