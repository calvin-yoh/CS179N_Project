using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Staff Student
public class ConstructionWorker : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }

    //Flip a coin. If heads, deal {5} damage to a target building. If tails, deal {3} damage to a target building.
    public override int PerformEffect(GameData data)
    {
        int luckModifier = GetLuckModifierValue(data.friendlyPlayer, data.self);
        var target = data.target[0];
        int headsEffectValue = 5 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();
        int tailsEffectValue = 3 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();

        if (FlipCoin(luckModifier) == 1)
        {
            target.gameObject.GetComponent<BuildingCardDisplay>().DamageBuilding(headsEffectValue);
            Debug.Log("Tour guide hit heads");
        }
        else
        {
            target.gameObject.GetComponent<BuildingCardDisplay>().DamageBuilding(tailsEffectValue);
            Debug.Log("Tour guide hit  coin flip");
        }
        return 0;
    }
}
