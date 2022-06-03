using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellTower : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Every other turn, you can put an additional student and faculty into play.
    public override int PerformEffect(GameData data)
    {
        if (data.self.turnsInPlay % 2 == 0){
            data.friendlyPlayer.ChangeNumStudentsCanPlace(1);
            data.friendlyPlayer.ChangeNumFacultyCanPlace(1);
        }
        return 0;
    }
}
