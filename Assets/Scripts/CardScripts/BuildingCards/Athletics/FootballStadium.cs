using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballStadium : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Athletic building
    // All Athletics cards gain {+1} effect power for each friendly student Athletics card.
    public override int PerformEffect(GameData data)
    {
        int athleteCount = 0;
        foreach(StudentCardDisplay s in data.friendlyStudents){
            if (s.GetCardMajor() == Card.Major.Athletics){
                athleteCount++;
            }
        }

        int effectValue = 1 + (athleteCount * data.self.GetEffectValueModifier());

        foreach(BuildingCardDisplay b in data.friendlyBuildings){
            if (b.GetCardMajor() == Card.Major.Athletics){
                b.SetEffectValueModifier(b.GetEffectValueModifier() + effectValue);
            }
        }
        foreach(FacultyCardDisplay f in data.friendlyFaculties){
            if (f.GetCardMajor() == Card.Major.Athletics){
                f.SetEffectValueModifier(f.GetEffectValueModifier() + effectValue);
            }
        }
        foreach(StudentCardDisplay s in data.friendlyStudents){
            if (s.GetCardMajor() == Card.Major.Athletics){
                s.SetEffectValueModifier(s.GetEffectValueModifier() + effectValue);
            }
        }
        return 0;
    }
}
