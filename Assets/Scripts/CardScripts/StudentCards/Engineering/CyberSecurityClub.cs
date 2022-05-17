using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberSecurityClub : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        needsTargetting = false;
    }
    //Firewall - Grant all friendly buildings {2} armor.
    public override int PerformEffect(GameData data)
    {
        List<BuildingCardDisplay> temp = data.friendlyBuildings;

        int effectValue = 2 + data.self.GetEffectValueModifier();
        
        foreach(BuildingCardDisplay building in temp)
        {
            building.SetCardArmor(building.GetCardArmor() + effectValue);
        }

        return 0;
    }
}
