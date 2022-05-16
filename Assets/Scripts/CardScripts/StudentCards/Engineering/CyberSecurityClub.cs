using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberSecurityClub : CardEffect
{
    void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
    }

    //Firewall - Grant all friendly buildings 2 armor.
    public override int PerformEffect(GameData data)
    {
        List<BuildingCardDisplay> temp = data.friendlyBuildings;
        
        foreach(BuildingCardDisplay building in temp)
        {
            building.SetCardArmor(building.GetCardArmor() + 2);
        }

        return 0;
    }
}
