using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Staff Student
public class TourGuide : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Tour - Flip a coin. If heads, draw 1 card. If tails, nothing happens
    public override int PerformEffect(GameData data)
    {
        int luckModifier = GetLuckModifierValue(data.friendlyPlayer, data.self);

        if (FlipCoin(luckModifier) == 1)
        {
            data.friendlyPlayer.DrawCard();
            Debug.Log("Tour guide hit heads");
        }
        else
        {
            Debug.Log("Tour guide failed coin flip");
        }
        return 0;
    }
}
