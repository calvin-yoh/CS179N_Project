using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArena : CardEffect
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

    // When you summon an engineering student, summon a robotic {1} duration copy.
    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    public override void CardPassive(CardDisplay placedCard)
    {
        CardDisplay thisCard = gameObject.GetComponent<CardDisplay>();
        GameData data = GameManager.Instance.GetGameData(thisCard);

        StudentCardDisplay scd = placedCard.GetComponent<StudentCardDisplay>();
        if (scd != null && scd.GetCardMajor() == Card.Major.Engineering)
        {
            int effectValue = 1 + thisCard.GetEffectValueModifier();
            int index = 0;
            Player currPlayer = data.friendlyPlayer;
            while (currPlayer.GetField().CheckIfOccupied(index, Card.Type.Student)){           // Get next available index on the field
                index++;
                if (index >= 7){
                    Debug.Log("Student slots are full");
                    return;
                }
            }

            EventsManager em = currPlayer.GetEventsManager();
            em.OnCardPlayedFromHand -= CardPassive;
            CardDisplay newCopy = currPlayer.PlaceCard(index, placedCard);
            em.OnCardPlayedFromHand += CardPassive;    

            StudentCardDisplay newStudent = newCopy.GetComponent<StudentCardDisplay>();
            newStudent.SetDuration(effectValue);
        }
    }
}
