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
        LuckModifier lm = data.friendlyPlayer.GetLuckModifier();
        Card.Type cardType = data.self.GetCardType();
        Card.Major cardMajor = data.self.GetCardMajor();

        int luckModifier = GetLuckModifier(lm, cardType, cardMajor);

        if (FlipCoin(luckModifier) == 1)
        {
            data.friendlyPlayer.DrawCard();
        }
        else
        {
            Debug.Log("Tour guide failed coin flip");
        }
        return 0;
    }
}
