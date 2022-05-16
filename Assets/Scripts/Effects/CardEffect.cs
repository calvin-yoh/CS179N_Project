using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{
    public enum TargetType{
        AOEStudent,
        AOEBuilding,
        SingleStudent,
        SingleBuilding
    }

    public enum TargetTeam{
        Friendly,
        Enemy
    }

    public Card.Type targetType;
    public TargetTeam targetTeam;

    /// <summary>
    /// Performs the specific card effect. Should return the number of seconds the effect will take to resolve
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public abstract int PerformEffect(GameData data);
}
