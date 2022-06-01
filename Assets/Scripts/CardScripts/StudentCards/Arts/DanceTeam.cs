using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceTeam : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }
    
    public override int PerformEffect(GameData data){
        int luckModifier = GetLuckModifierValue(data.friendlyPlayer, data.self);

        if (FlipCoin(luckModifier) == 1){
            Debug.Log("Dance Team hit heads");
            for (int i = 0; i < 2; i++){
                int randIndex = Random.Range(0, data.enemyStudents.Count);
                var student = data.enemyStudents[randIndex];
                student.DistractCard();
                Debug.Log("Dance Team distracted a student: " + student.GetCardName());
            }
        }
        else{
            Debug.Log("Dance Team hit tails");
            for (int i = 0; i < 2; i++){
                int randIndex = Random.Range(0, data.friendlyStudents.Count);
                var student = data.friendlyStudents[randIndex];
                student.DistractCard();
                Debug.Log("Dance Team distracted a student: " + student.GetCardName());
            }
        }

        return 0;
    }
}
