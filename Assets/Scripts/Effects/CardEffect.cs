using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{
    /// <summary>
    /// Performs the specific card effect. Should return the number of seconds the effect will take to resolve
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public abstract int PerformEffect(GameData data);
}
