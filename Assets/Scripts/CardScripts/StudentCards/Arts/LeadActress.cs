using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadActress : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }


    public override int PerformEffect(GameData data)
    {
        int baseDamage = 2;
        data.self.SetEffectValueModifier(data.self.GetEffectValueModifier() + (baseDamage * data.self.turnsInPlay));
        int damage = baseDamage + data.self.GetEffectValueModifier();
        BuildingCardDisplay building = (BuildingCardDisplay)data.target[0];
        building.DamageBuilding(damage);
        Debug.Log("LeadActress did " + damage + " damage to " + building.GetCardName());
        Debug.Log("LeadActress has been in play for " + data.self.turnsInPlay + " turns. " + "Damage is " + damage);
        return 0;
    }
}
