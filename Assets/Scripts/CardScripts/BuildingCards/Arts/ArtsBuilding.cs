using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtsBuilding : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    //Every turn, this building recovers {2} health points.
    public override int PerformEffect(GameData data)
    {
        BuildingCardDisplay thisBuilding = data.self.GetComponent<BuildingCardDisplay>();

        int effectValue = 2 + data.self.GetEffectValueModifier();

        thisBuilding.HealBuilding(effectValue);

        return 0;
    }
}
