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

    //Flip a coin. 0 for Heads. 1 for Tails
    public int FlipCoin(int luckModifier)
    {
        int rand = Random.Range(0, 100);

        if (rand < 50 + luckModifier)
            return 0;
        else
            return 1;
    }    
}
