using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custodian : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Friendly;
        numTargets = 0;
    }

    // Clean - Heal all friendly buildings by {2}.
    public override int PerformEffect(GameData data){
        return 0;
    }
}
