using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningHall : CardEffect
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

    // All your students cards gain +1 effect value.
    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    public override void CardPassive(CardDisplay card)
    {
        StudentCardDisplay scd = card.GetComponent<StudentCardDisplay>();
        if (scd != null)
        {
            scd.SetEffectValueModifier(scd.GetEffectValueModifier() + 1);
        }
    }
}
