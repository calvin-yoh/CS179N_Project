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

    // Target 2 buildings. For each target, if it is an enemy, deal {5} damage. If it is friendly, heal it by {1} health.
    public override int PerformEffect(GameData data)
    {
        foreach (CardDisplay card in data.target){
            
        }
        foreach (CardDisplay card in data.target){
            BuildingCardDisplay building;
            if (card.TryGetComponent(out building)){

            }
            else{
                Debug.Log("Invalid target selected for film professor");
            }

        }


        return 0;
    }
}
