    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboardingClub : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Flip a coin. If heads, deal {5} damage to all enemy buildings. If tails, deal {3} damage to all friendly buildings.
    public override int PerformEffect(GameData data)
    {
        int luckModifier = GetLuckModifierValue(data.friendlyPlayer, data.self);
        List<BuildingCardDisplay> buildingsToDamage;
        int damage;

        if (FlipCoin(luckModifier) == 1)
        {
            buildingsToDamage = data.enemyBuildings;
            damage = 5 + data.self.GetEffectValueModifier();
            Debug.Log("Snowboarding Club hit heads");
        }
        else
        {
            buildingsToDamage = data.friendlyBuildings;
            damage = 3 + data.self.GetEffectValueModifier();
            Debug.Log("Snowboarding Club hit tails");
        }

        foreach (BuildingCardDisplay building in buildingsToDamage){
            building.DamageBuilding(damage);
        }
        return 0;
    }
}
