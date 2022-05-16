using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Architect : CardEffect
{
    //Shield Craft - Grant a target building 6 armor.
    public override int PerformEffect(GameData data)
    {
        GameObject go = data.target.gameObject;
        BuildingCardDisplay target;

        if (go.TryGetComponent(out target))
        {
            target.SetCardArmor(target.GetCardArmor() + 6);
            Debug.Log("Architect worked");
        }
        else
        {
            Debug.Log("Architect Card Effect Error");
        }
        return 0;
    }
}
