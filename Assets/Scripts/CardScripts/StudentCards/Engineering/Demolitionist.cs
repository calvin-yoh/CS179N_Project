using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demolitionist : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }
    //Deal {6} damage to an opposing non-engineering building.
    public override int PerformEffect(GameData data)
    {
        if(data.target[0].GetCardType() != Card.Type.Building)
        {
            return -1;
        }

        BuildingCardDisplay target;
        int effectValue = 6 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();
        
        if (data.target[0].gameObject.TryGetComponent(out target) && target.GetCardMajor() != Card.Major.Engineering)
        {
                target.DamageBuilding(effectValue);
                Debug.Log("Demolitionist Worked");
        }
        else{
            Debug.Log("Demolitionist Error or Targetted Engineering Building");
        }
        
        return 0;
    }
}
