using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourGuide : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
    }

    // Tour - Flip a coin. If heads, draw 1 card. If tails, nothing happens
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
