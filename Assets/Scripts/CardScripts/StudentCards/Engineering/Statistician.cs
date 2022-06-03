using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistician : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }

    //Engineer
    //Student
    //Flip a coin. If heads, target building takes {8} damage. If tails, nothing happens.
    public override int PerformEffect(GameData data)
    {
        if (data.target[0].GetCardType() != Card.Type.Building)
        {
            return -1;
        }

        GameObject go = data.target[0].gameObject;
        BuildingCardDisplay target;

        if (go.TryGetComponent(out target))
        {
            int luckModifier = GetLuckModifierValue(data.friendlyPlayer, data.self);
            int effectValue = 8 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();

            if (FlipCoin(luckModifier) == 1)
            {
                target.DamageBuilding(effectValue);
            }
            else
            {
                Debug.Log("Statistician failed coin flip");
            }
        }
        else
        {
            Debug.Log("Statistician Card Effect Error");
        }
        return 0;
    }
}
