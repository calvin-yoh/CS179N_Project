using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerLab : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // All friendly engineering card's "Flip a coin effects" are {15}% more likely to land on heads.
    public override int PerformEffect(GameData data)
    {
        int effectValue = 15 + data.self.GetEffectValueModifier();
        LuckModifier modifier = data.friendlyPlayer.GetLuckModifier();

        modifier.ChangeEngineeringLuckModifier(effectValue);
        return 0;
    }
}
