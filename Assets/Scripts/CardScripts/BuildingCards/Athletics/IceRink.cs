using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRink : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Your Athletics card's "Flip a coin effects" are {20}% more likely to land on heads.
    public override int PerformEffect(GameData data)
    {
        int effectValue = 20 + data.self.GetEffectValueModifier();
        LuckModifier modifier = data.friendlyPlayer.GetLuckModifier();

        modifier.ChangeAthleticsLuckModifier(effectValue);
        return 0;
    }
}
