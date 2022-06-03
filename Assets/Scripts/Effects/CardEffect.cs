using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{
    public enum TargetTeam{
        Friendly,
        Enemy
    }

    // Used for AI, does not affect the player decisions
    public Card.Type targetType;    // What kind of cards this effect targets
    public TargetTeam targetTeam;   // Whether this card should target friendly cards or enemy cards
    public int numTargets;         // How many cards this can target
    public bool isChooseOne;        // Whether this card is choose one or not   

    protected abstract void Start();   // Declare targetType and targetTeam here

    /// <summary>
    /// Performs the specific card effect. Should return the number of seconds the effect will take to resolve
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public abstract int PerformEffect(GameData data);

    public virtual void CardPassive(CardDisplay card) { return; }

    //Flip a coin. 0 for Tails. 1 for Head
    public int FlipCoin(int luckModifier)
    {
        int rand = Random.Range(0, 100);

        if (rand < 50 + luckModifier)
            return 1;
        else
            return 0;
    }

    public int GetLuckModifierValue(Player friendlyPlayer, CardDisplay self)
    {
        int total = 0;

        LuckModifier modifier = friendlyPlayer.GetLuckModifier();
        Card.Type cardType = self.GetCardType();
        Card.Major cardMajor = self.GetCardMajor();

        switch (cardType)
        {
            case Card.Type.Student:
                total += modifier.GetStudentLuckModifier();
                break;
            case Card.Type.Faculty:
                total += modifier.GetFacultyLuckModifier();
                break;
            default:
                Debug.Log("Getting luck modifier failed");
                break;
        }
        switch (cardMajor)
        {
            case Card.Major.Athletics:
                total += modifier.GetAthleticsLuckModifier();
                break;
            case Card.Major.Arts:
                total += modifier.GetArtsLuckModifier();
                break;
            case Card.Major.Engineering:
                total += modifier.GetEngineeringLuckModifier();
                break;
            case Card.Major.Staff:
                total += modifier.GetStaffLuckModifier();
                break;
            default:
                Debug.Log("Getting luck modifier failed");
                break;
        }
        return total;
    }

    public List<BuildingCardDisplay> ChooseRandomBuildings(List<BuildingCardDisplay> list, int count)
    {
        List<BuildingCardDisplay> result = new List<BuildingCardDisplay>();

        if (list.Count <= count)
        {
            return list;
        }

        for (int i = 0; i < count; i++)
        {
            int tempTarget = Random.Range(0, list.Count);
            result.Add(list[tempTarget]);
            list.RemoveAt(tempTarget);
        }
        return result;
    }
}
