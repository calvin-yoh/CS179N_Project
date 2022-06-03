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
        if (data.target[0].GetCardType() != Card.Type.Building)
        {
           return -1;
        }
        
        int baseDamage = 2;
        int damage = baseDamage + (data.self.turnsInPlay * baseDamage);
        BuildingCardDisplay building = (BuildingCardDisplay)data.target[0];
        building.DamageBuilding(damage);
        Debug.Log("LeadActress did " + damage + " damage to " + building.GetCardName());
        Debug.Log("LeadActress has been in play for " + data.self.turnsInPlay + " turns. " + "Damage is " + damage);
        return 0;
    }
}
