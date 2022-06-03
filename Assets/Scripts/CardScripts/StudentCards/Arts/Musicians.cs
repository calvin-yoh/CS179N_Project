using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicians : CardEffect
{
    // Start is called before the first frame update
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }

    public override int PerformEffect(GameData data)
    {
        // add one duration to all friendly students
        foreach (StudentCardDisplay student in data.friendlyStudents)
        {
            if(student.GetCardName() == "Musicians")
            {
                continue;
            }
            student.ChangeDurationBy(1);
        }

        // add one duration to all enemy students
        foreach (StudentCardDisplay student in data.enemyStudents)
        {
            if(student.GetCardName() == "Musicians")
            {
                continue;
            }
            student.ChangeDurationBy(1);
        }
        return 0;
    }
}
