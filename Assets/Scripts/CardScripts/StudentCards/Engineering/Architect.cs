using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Architect : CardEffect
{

    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
    }
    //Shield Craft - Grant a target building 6 armor.
    public override int PerformEffect(GameData data)
    {
        GameObject go = data.target.gameObject;
        BuildingCardDisplay target;

        int effectValue = 6 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();

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
