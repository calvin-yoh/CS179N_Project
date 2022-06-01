using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballCourt : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Athletic building
    // If you have exactly 5 students on the field, your Athletics cards gain {+5} effect value.
    public override int PerformEffect(GameData data)
    {
        int studentCount = data.friendlyStudents.Count;
        int effectValue = 5 + data.self.GetEffectValueModifier();

        if (studentCount == 5){
            foreach(StudentCardDisplay s in data.friendlyStudents){
                if (s.GetCardMajor() == Card.Major.Athletics){
                    s.SetEffectValueModifier(s.GetEffectValueModifier() + effectValue);
                }
            }
        }
        return 0;
    }
}
