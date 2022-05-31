using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerStriker : CardEffect
{
    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }
    // Deal {3} damage to a target enemy building. For every Soccer card on the field, do 1 more.
    public override int PerformEffect(GameData data)
    {
        GameObject go = data.target[0].gameObject;
        BuildingCardDisplay target;

        int baseDamage = 3 + data.self.GetEffectValueModifier();
        int soccerCount = -1;
        foreach (CardDisplay c in data.friendlyBuildings){
            string s = c.GetCardName();
            if (s.Contains("Soccer")){
                soccerCount++;
            }
        }
        foreach (CardDisplay c in data.friendlyFaculties){
            string s = c.GetCardName();
            if (s.Contains("Soccer")){
                soccerCount++;
            }
        }
        foreach (CardDisplay c in data.friendlyStudents){
            string s = c.GetCardName();
            if (s.Contains("Soccer")){
                soccerCount++;
            }
        }
        foreach (CardDisplay c in data.enemyBuildings){
            string s = c.GetCardName();
            if (s.Contains("Soccer")){
                soccerCount++;
            }
        }
        foreach (CardDisplay c in data.enemyFaculties){
            string s = c.GetCardName();
            if (s.Contains("Soccer")){
                soccerCount++;
            }
        }
        foreach (CardDisplay c in data.enemyStudents){
            string s = c.GetCardName();
            if (s.Contains("Soccer")){
                soccerCount++;
            }
        }
        int bonusDamage = soccerCount;

        if (go.TryGetComponent(out target))
        {
            target.DamageBuilding(baseDamage + bonusDamage);
        }
        else
        {
            return -1;
        }
        return 0;
    }
}
