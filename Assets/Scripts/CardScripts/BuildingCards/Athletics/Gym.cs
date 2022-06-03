using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gym : CardEffect
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

    // All your Athletics cards gain +1 duration when played.
    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    public override void CardPassive(CardDisplay card)
    {
        StudentCardDisplay scd;
        if (card.TryGetComponent(out scd))
        {
            if (scd.GetCardMajor() == Card.Major.Athletics){
                Debug.Log("Gym building increased dur");
                scd.ChangeDurationBy(1);
            }
        }
    }
}
