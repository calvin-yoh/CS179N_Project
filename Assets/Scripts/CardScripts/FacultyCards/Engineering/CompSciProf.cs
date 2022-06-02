using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompSciProf : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }
    //Distract a target enemy faculty card for 1 turn.
    public override int PerformEffect(GameData data)
    {
        GameObject go = data.target[0].gameObject;
        FacultyCardDisplay target;

        // //int effectValue = 6 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();

        // List<BuildingCardDisplay> temp = data.enemyBuildings;

        // foreach(BuildingCardDisplay building in temp)
        // {
        //     building.DamageBuilding()
        // }


        // foreach(BuildingCardDisplay building in temp)
        // {
        //     building.SetCardArmor(building.GetCardArmor() + effectValue);
        // }

        // if (go.TryGetComponent(out target))
        // {
        //     target.DistractCard();
        //     Debug.Log("Photographer effect worked");
        // }
        // else
        // {
        //     Debug.Log("Photographer card effect error");
        //     return -1;
        // }
        return 0;
    }

}
