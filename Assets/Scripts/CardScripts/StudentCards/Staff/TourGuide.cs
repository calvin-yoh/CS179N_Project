using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourGuide : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        needsTargetting = false;
    }

    // Tour - Flip a coin. If heads, draw 1 card. If tails, nothing happens
    public override int PerformEffect(GameData data)
    {
        
        return 0;
    }
}
