using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballTeam : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }

    // Deal {6} damage to a target enemy building. If there is no enemy Athletic card, deal {3} more.
    public override int PerformEffect(GameData data)
    {
        if(data.target[0].GetCardType() != Card.Type.Building)
        {
            return -1;
        }

        int damage = 6 + data.self.GetEffectValueModifier();
        int bonusDamage = 3 + data.self.GetEffectValueModifier();

        foreach (StudentCardDisplay stud in data.enemyStudents){
            if (stud.GetCardMajor() == Card.Major.Athletics){
                bonusDamage = 0;
                break;
            }
        }
        GameObject targ = data.target[0].gameObject;
        BuildingCardDisplay bd;
        if (targ.TryGetComponent(out bd)){
            bd.DamageBuilding(damage + bonusDamage);
        }
        else{
            Debug.Log("Invalid target for football team");
            return -1;
        }
        return 0;
    }
}
