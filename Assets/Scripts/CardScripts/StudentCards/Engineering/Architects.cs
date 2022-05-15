using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Architects : CardEffect
{ 
    public override int PerformEffect(GameData data)
    {
        GameObject go = data.target.gameObject;
        BuildingCardDisplay target;

        if (go.TryGetComponent(out target))
        {
            target.SetCardArmor(target.GetCardArmor() + 6);
        }
        else
        {
            Debug.Log("Architect Card Effect Error");
        }
        return 0;
    }
}
