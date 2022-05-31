using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGoalkeeper : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 0;
    }

    // Flip a coin. If heads, grant {6} armor to a random friendly building. If tails, grant a random enemy student +1 duration. 
    public override int PerformEffect(GameData data)
    {

        int luckModifier = GetLuckModifierValue(data.friendlyPlayer, data.self);

        if (FlipCoin(luckModifier) == 1)
        {
            if (data.friendlyBuildings.Count > 0){
                int randIndex = Random.Range(0, data.friendlyBuildings.Count);
                BuildingCardDisplay randBuilding = data.friendlyBuildings[randIndex];
                int armorGained = 6 + data.self.GetEffectValueModifier() + randBuilding.GetCardArmor();
                randBuilding.SetCardArmor(armorGained);
            }
            Debug.Log("Goalkeeper hit heads");
        }
        else
        {
            if (data.enemyStudents.Count > 0){
                int randIndex = Random.Range(0, data.enemyStudents.Count);
                StudentCardDisplay randStudent = data.enemyStudents[randIndex];
                randStudent.ChangeDurationBy(1);
            }
            Debug.Log("Goalkeeper failed coin flip");
        }
        return 0;
    }
}
