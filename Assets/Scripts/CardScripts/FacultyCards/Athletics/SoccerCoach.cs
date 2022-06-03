using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerCoach : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Trigger all friendly Soccer student effects. Targets are randomized.
    public override int PerformEffect(GameData data)
    {
        foreach (StudentCardDisplay student in data.friendlyStudents){
            if (student.GetCardName().Contains("Soccer")){
                CardDisplay temp;
                FieldLayout field = data.friendlyPlayer.GetField();
                List<CardDisplay> target = new List<CardDisplay>();
                if (student.GetCardEffectScript().targetTeam == CardEffect.TargetTeam.Friendly){
                    temp = field.GetRandomCard(student.GetCardEffectScript().targetType);
                    if (temp != null) target.Add(temp);

                }
                else{
                    temp = data.enemyPlayer.GetField().GetRandomCard(student.GetCardEffectScript().targetType);
                    if (temp != null) target.Add(temp);
                }

                data.target = target;
                student.GetCardEffectScript().PerformEffect(data);
            }
        }

        return 0;
        
    }
}
