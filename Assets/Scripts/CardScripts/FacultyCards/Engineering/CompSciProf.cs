using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompSciProf : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }
    //
    public override int PerformEffect(GameData data)
    {

        bool containsCSBuilding = false;
        foreach (BuildingCardDisplay building in data.friendlyBuildings){
            if(building.GetCardMajor() == Card.Major.Engineering)
                containsCSBuilding = true;
        }

        if(containsCSBuilding){
            var damage = 5 + data.self.GetEffectValueModifier();
            Debug.Log("CompSci prof damages enemy buildings");

            foreach (BuildingCardDisplay building in data.enemyBuildings){
                building.DamageBuilding(damage);
            }
        }


        return 0;
    }
}
