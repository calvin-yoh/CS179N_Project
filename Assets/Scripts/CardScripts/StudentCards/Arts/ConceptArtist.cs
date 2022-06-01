using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConceptArtist : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    public override int PerformEffect(GameData data){
        var addedHealth = 2 + data.self.GetEffectValueModifier();

        foreach(BuildingCardDisplay building in data.friendlyBuildings){
            building.HealBuilding(addedHealth);
            Debug.Log("Concept Artist healed a building: " + building.GetCardName() + " HP: " + building.GetCardHealth());
        }
        
        return 0;
    }
}
