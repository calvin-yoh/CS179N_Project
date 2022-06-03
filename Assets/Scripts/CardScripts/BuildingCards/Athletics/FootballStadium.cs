using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballStadium : CardEffect
{
    private int athleteCount;

    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
        athleteCount = 0;
    }

    private void OnEnable()
    {
        int playerNumber = gameObject.GetComponent<CardDisplay>().playerNumber;
        Player currPlayer = GameManager.Instance.players[playerNumber - 1];
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand += CardPassive;    
    }

    private void OnDisable()
    {
        int playerNumber = gameObject.GetComponent<CardDisplay>().playerNumber;
        Player currPlayer = GameManager.Instance.players[playerNumber - 1];
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand -= CardPassive;
    }

    // Athletic building
    // All Athletic student cards gain {+1} effect power for each friendly student Athletics card.
    public override int PerformEffect(GameData data)
    {
        athleteCount = 0;
        foreach(StudentCardDisplay s in data.friendlyStudents){
            if (s.GetCardMajor() == Card.Major.Athletics){
                athleteCount++;
            }
        }

        int effectValue = athleteCount * (1 + data.self.GetEffectValueModifier());

        foreach(StudentCardDisplay s in data.friendlyStudents){
            if (s.GetCardMajor() == Card.Major.Athletics){
                s.SetEffectValueModifier(s.GetEffectValueModifier() + effectValue);
            }
        }
        return 0;
    }

    public override void CardPassive(CardDisplay placedCard)
    {
        CardDisplay thisCard = gameObject.GetComponent<CardDisplay>();
        GameData data = GameManager.Instance.GetGameData(thisCard);
        StudentCardDisplay scd = placedCard.GetComponent<StudentCardDisplay>();
        if (placedCard.GetCardMajor() == Card.Major.Athletics && scd != null){

            athleteCount++;
            int effectValue = 1 + thisCard.GetEffectValueModifier();
            placedCard.SetEffectValueModifier(placedCard.GetEffectValueModifier() + (athleteCount * effectValue));

            foreach(StudentCardDisplay s in data.friendlyStudents){
                if (s.GetCardMajor() == Card.Major.Athletics && s != placedCard){
                    s.SetEffectValueModifier(s.GetEffectValueModifier() + effectValue);
                }
            }
        }
    }
}
