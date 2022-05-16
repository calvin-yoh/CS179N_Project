using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDevelopers : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
    }
    public override int PerformEffect(GameData data)
    {

        return 0;
    }
}
