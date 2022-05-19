using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicDesignClub : CardEffect
{
	protected override void Start()
	{
		targetType = Card.Type.Building;
		targetTeam = TargetTeam.Enemy;
		numTargets = 0;
	}
	//Deal {4} damage to 2 random enemy buildings. Requires 1 friendly art building.
	public override int PerformEffect(GameData data)
	{
		List<BuildingCardDisplay> friendlies = data.friendlyBuildings;
		List<BuildingCardDisplay> enemies = data.enemyBuildings;

		int effectValue = 4 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();

		bool canActivateEffect = false;

		foreach (var x in friendlies)
		{
			if (x.GetCardMajor() == Card.Major.Arts)
			{
				canActivateEffect = true;
				break;
			}
		}

		if (canActivateEffect)
		{
			var randomTargets = ChooseRandomBuildings(enemies, 2);
			foreach (var t in randomTargets)
			{
				t.DamageBuilding(effectValue);
			}
			Debug.Log("Graphic Design Club card effect worked");
		}
		else
		{
			Debug.Log("Graphic Design Club card effect error");
			return -1;
		}
		return 0;
	}
}