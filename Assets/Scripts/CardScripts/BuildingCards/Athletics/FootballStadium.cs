using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballStadium : CardEffect
{
    private int athleteCount;
    private GameData data;

    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    private void OnEnable()
    {
        Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand += CardPassive;    
    }

    private void OnDisable()
    {
        Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand -= CardPassive;
    }

    // Athletic building
    // All Athletics cards gain {+1} effect power for each friendly student Athletics card.
    public override int PerformEffect(GameData data)
    {
        this.data = data;
        int athleteCount = 0;
        foreach(StudentCardDisplay s in data.friendlyStudents){
            if (s.GetCardMajor() == Card.Major.Athletics){
                athleteCount++;
            }
        }

        int effectValue = athleteCount * (1 + data.self.GetEffectValueModifier());

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

    public override void CardPassive(CardDisplay card)
    {
        
        // if (card.GetCardMajor() == Card.Major.Athletics){

        //     athleteCount++;
        //     int effectValue = 1 * data.self.GetEffectValueModifier();
        //     card.SetEffectValueModifier(card.GetEffectValueModifier() + (athleteCount * data.self.GetEffectValueModifier()));

        //     foreach(BuildingCardDisplay b in data.friendlyBuildings){
        //         if (b.GetCardMajor() == Card.Major.Athletics){
        //             b.SetEffectValueModifier(b.GetEffectValueModifier() + effectValue);
        //         }
        //     }
        //     foreach(FacultyCardDisplay f in data.friendlyFaculties){
        //         if (f.GetCardMajor() == Card.Major.Athletics){
        //             f.SetEffectValueModifier(f.GetEffectValueModifier() + effectValue);
        //         }
        //     }
        //     foreach(StudentCardDisplay s in data.friendlyStudents){
        //         if (s.GetCardMajor() == Card.Major.Athletics){
        //             s.SetEffectValueModifier(s.GetEffectValueModifier() + effectValue);
        //         }
        //     }
        // }
    }
}
