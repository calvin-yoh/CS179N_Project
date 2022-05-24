using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Deal {6} damage to an opposing non-engineering building.
public class Demolitionist : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }
    //All non-engineering building takes {5} damage. Requires 1 friendly engineering building.
    public override int PerformEffect(GameData data)
    {
        
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
