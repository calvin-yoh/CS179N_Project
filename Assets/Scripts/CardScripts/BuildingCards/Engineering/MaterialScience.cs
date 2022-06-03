using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScience : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Non-engineering buildings take double damage.
    public override int PerformEffect(GameData data)
    {
        foreach (BuildingCardDisplay b in data.friendlyBuildings){
            if (b.GetCardMajor() != Card.Major.Engineering){
                b.SetBuildingWeaken(true);
            }
        }
        foreach (BuildingCardDisplay b in data.enemyBuildings){
            if (b.GetCardMajor() != Card.Major.Engineering){
                b.SetBuildingWeaken(true);
            }
        }
        return 0;
    }
}
