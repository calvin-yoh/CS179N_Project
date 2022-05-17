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

    //Flip a coin. 0 for Tails. 1 for Head
    public int FlipCoin(int luckModifier)
    {
        int rand = Random.Range(0, 100);

        if (rand < 50 + luckModifier)
            return 1;
        else
            return 0;
    }

    public int GetLuckModifier(LuckModifier modifier, Card.Type type, Card.Major major)
    {
        int total = 0;
        switch(type)
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
        switch (major)
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
}
