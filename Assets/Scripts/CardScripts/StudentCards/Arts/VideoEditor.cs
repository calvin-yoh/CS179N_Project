using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoEditor : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }
    //Deal {4} damage to a target building.
    public override int PerformEffect(GameData data)
    {
        GameObject go = data.target[0].gameObject;
        BuildingCardDisplay target;

        int effectValue = 4 + data.self.GetEffectValueModifier();

        if (go.TryGetComponent(out target))
        {
            target.DamageBuilding(effectValue);
            Debug.Log("Video Editor effect worked");
        }
        else
        {
            Debug.Log("Video Editor card effect error");
            return -1;
        }
        return 0;
    }
}