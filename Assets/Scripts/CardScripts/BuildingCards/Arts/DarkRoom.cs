using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoom : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }

    //When your turn starts, this building switches health with an random opponent's building.
    public override int PerformEffect(GameData data)
    {
        List<BuildingCardDisplay> enemyDisplays = data.enemyBuildings;

        var targetList = ChooseRandomBuildings(enemyDisplays, 1);

        BuildingCardDisplay target = targetList[0];
        BuildingCardDisplay self = data.self as BuildingCardDisplay;

        int targetHealth = target.GetCardHealth();
        int selfHealth = self.GetCardHealth();

        self.SetCardHealth(targetHealth);
        target.SetCardHealth(selfHealth);

        Debug.Log("Dark Room switched health with " + target.name);
        return 0;
    }
}