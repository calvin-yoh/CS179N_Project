using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicians : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }


    public override int PerformEffect(GameData data)
    {
        foreach(StudentCardDisplay student in data.friendlyStudents){
            if(student.GetCardName() == data.self.GetCardName()){ continue; }
            student.ChangeDurationBy(1);
            Debug.Log("Musicians increased duration of friend: " + student.GetCardName() + " by 1");
        }
        foreach(StudentCardDisplay student in data.enemyStudents){
            if(student.GetCardName() == data.self.GetCardName()){ continue; }
            student.ChangeDurationBy(1);
            Debug.Log("Musicians increased duration of enemy: " + student.GetCardName() + " by 1");
        }
        
        return 0;
    }
}
