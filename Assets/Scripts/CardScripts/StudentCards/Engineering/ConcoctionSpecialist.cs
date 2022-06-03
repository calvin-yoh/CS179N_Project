using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcoctionSpecialist : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }
    //Deal {3} damage to an opposing building.
    public override int PerformEffect(GameData data)
    {
        if (data.target[0].GetCardType() != Card.Type.Building)
        {
            return -1;
        }
        BuildingCardDisplay target;
        int effectValue = 3 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();
        
        if (data.target[0].gameObject.TryGetComponent(out target))
        {
                target.DamageBuilding(effectValue);
                Debug.Log("Concoction Specialist Worked");
        }
        else{
            Debug.Log("Concoction Specialist Error");
        }
        
        return 0;
    }
}
