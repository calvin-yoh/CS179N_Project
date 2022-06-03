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
    // If you have exactly 5 students on the field, your Athletics cards gain {+5} effect value.
    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    public override void CardPassive(CardDisplay placedCard)
    {
        CardDisplay thisCard = gameObject.GetComponent<CardDisplay>();
        GameData data = GameManager.Instance.GetGameData(thisCard);

        StudentCardDisplay scd = placedCard.GetComponent<StudentCardDisplay>();

        int studentCount = data.friendlyStudents.Count;
        if (studentCount == 5 && scd != null){
            int effectValue = 5 + thisCard.GetEffectValueModifier();

            foreach (StudentCardDisplay s in data.friendlyStudents){
                if (s.GetCardMajor() == Card.Major.Athletics){
                    s.SetEffectValueModifier(s.GetEffectValueModifier() + effectValue);
                }
            }
        }
    }
}
