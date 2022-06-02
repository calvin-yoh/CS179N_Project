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

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
    }

    // Your Athletics card's "Flip a coin effects" are {20}% more likely to land on heads.
    public override int PerformEffect(GameData data)
    {
        return 0;
    }
}
