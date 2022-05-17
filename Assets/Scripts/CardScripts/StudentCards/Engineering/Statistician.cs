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
        GameObject go = data.target[0].gameObject;
        BuildingCardDisplay target;

        if (go.TryGetComponent(out target))
        {
            LuckModifier lm = data.friendlyPlayer.GetLuckModifier();
            Card.Type cardType = data.self.GetCardType();
            Card.Major cardMajor = data.self.GetCardMajor();

            int luckModifier = GetLuckModifier(lm, cardType, cardMajor);
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
