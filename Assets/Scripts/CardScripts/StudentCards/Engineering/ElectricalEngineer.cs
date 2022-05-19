using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalEngineer : CardEffect
{

    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }
    //All non-engineering building takes {5} damage. Requires 1 friendly engineering building.
    public override int PerformEffect(GameData data)
    {
        List<BuildingCardDisplay> friendly = data.friendlyBuildings;
        List<BuildingCardDisplay> enemy = data.enemyBuildings;

        int effectValue = 5 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();

        bool canActivateEffect = false;

        foreach (var x in friendly)
        {
            if (x.GetCardMajor() == Card.Major.Engineering)
            {
                canActivateEffect = true;
                break;
            }
        }

        if (canActivateEffect)
        {
            foreach (var x in friendly)
            {
                if (x.GetCardMajor() != Card.Major.Engineering)
                {
                    x.DamageBuilding(effectValue);
                }
            }
            foreach (var y in enemy)
            {
                if (y.GetCardMajor() != Card.Major.Engineering)
                {
                    y.DamageBuilding(effectValue);
                }
            }
            Debug.Log("Electrical Engineer worked");
        }
        else
        {
            Debug.Log("Electrical Engineer Card Effect Error");
            return -1;
        }
        return 0;
    }
}
