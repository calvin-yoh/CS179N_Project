using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmProfessor : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 2;
    }

    // Target 2 buildings. For each target, if it is an enemy, deal {5} damage. If it is friendly, heal it by {3} health.
    public override int PerformEffect(GameData data)
    {
        foreach (CardDisplay card in data.target){
            if (card.GetCardType() != Card.Type.Building){
                Debug.Log("Invalid target selected for film professor");
                return -1;
            }
        }


        foreach (CardDisplay card in data.target){
            Debug.Log(card);
            BuildingCardDisplay building;
            if (card.TryGetComponent(out building)){
                int damageValue = 5 + data.self.GetEffectValueModifier();
                int healValue = 3 + data.self.GetEffectValueModifier();

                if (building.playerNumber == data.friendlyPlayer.number){
                    building.HealBuilding(healValue);
                }
                else{
                    building.DamageBuilding(damageValue);
                }
            }
        }


        return 0;
    }
}
