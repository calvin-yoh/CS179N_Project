using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAndField : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // You can summon 1 extra student on your turn.
    public override int PerformEffect(GameData data)
    {
        Debug.Log("Track and field - Increasing student count");
        data.friendlyPlayer.ChangeNumStudentsCanPlace(1);
        return 0;
    }
}
