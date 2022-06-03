using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompSciProf : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }

    // If your opponent has 0 Engineering buildings, deal {10} damage to all your opponents buildings
    public override int PerformEffect(GameData data)
    {

        bool containsCSBuilding = false;
        foreach (BuildingCardDisplay building in data.enemyBuildings){
            if(building.GetCardMajor() == Card.Major.Engineering){
                containsCSBuilding = true;
                break;
            }
        }

        if(!containsCSBuilding){
            var damage = 10 + data.self.GetEffectValueModifier();
            Debug.Log("CompSci prof damages enemy buildings");

            foreach (BuildingCardDisplay building in data.enemyBuildings){
                building.DamageBuilding(damage);
            }
        }


        return 0;
    }
}
