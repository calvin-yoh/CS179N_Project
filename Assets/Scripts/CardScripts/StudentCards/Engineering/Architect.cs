using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Architect : CardEffect
{

    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 1;
    }
    //Shield Craft - Grant a target building 6 armor.
    public override int PerformEffect(GameData data)
    {
        GameObject go = data.target[0].gameObject;
        BuildingCardDisplay target;

        int effectValue = 6 + data.self.GetEffectValueModifier();

        if (go.TryGetComponent(out target))
        {
            target.SetCardArmor(target.GetCardArmor() + effectValue);
            Debug.Log("Architect worked");
        }
        else
        {
            Debug.Log("Architect Card Effect Error");
        }
        return 0;
    }
}
