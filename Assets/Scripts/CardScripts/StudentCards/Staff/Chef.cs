using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Friendly;
        numTargets = 1;
    }
    //Grant a target student +2 effect value.
    public override int PerformEffect(GameData data)
    {
        if (data.target[0].GetCardType() != Card.Type.Student)
        {
            return -1;
        }

        GameObject go = data.target[0].gameObject;
        StudentCardDisplay target;

        int effectValue = 2;

        if (go.TryGetComponent(out target))
        {
            target.SetEffectValueModifier(target.GetEffectValueModifier() + effectValue);
            Debug.Log("Chef worked");
        }
        else
        {
            Debug.Log("Chef Card Effect Error");
        }
        return 0;
    }
}
