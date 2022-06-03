using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theater : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    private void OnEnable()
    {
        int playerNumber = gameObject.GetComponent<CardDisplay>().playerNumber;
        Player currPlayer = GameManager.Instance.players[playerNumber - 1];
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand += CardPassive;
        em.OnCardRemovedFromField += CardPassive;
    }

    private void OnDisable()
    {
        int playerNumber = gameObject.GetComponent<CardDisplay>().playerNumber;
        Player currPlayer = GameManager.Instance.players[playerNumber - 1];
        EventsManager em = currPlayer.GetEventsManager();
        em.OnCardPlayedFromHand -= CardPassive;
        em.OnCardRemovedFromField -= CardPassive;
    }

    public override int PerformEffect(GameData data)
    {
        return 0;
    }

    //If any friendly Actor card is in play, this building cannot be attacked.
    public override void CardPassive(CardDisplay card)
    {
        GameData data = GameManager.Instance.GetGameData(card);

        BuildingCardDisplay bd = this.GetComponent<BuildingCardDisplay>();

        foreach (CardDisplay c in data.friendlyFaculties)
        {
            string s = c.GetCardName();
            if (s.Contains("Actor"))
            {
                bd.SetBuildingImmunity(true);
                return;
            }
        }
        foreach (CardDisplay c in data.friendlyStudents)
        {
            string s = c.GetCardName();
            if (s.Contains("Actor"))
            {
                bd.SetBuildingImmunity(true);
                return;
            }
        }

        bd.ResetImmunity();
    }
}