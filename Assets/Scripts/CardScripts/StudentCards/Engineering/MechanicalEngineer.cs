using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalEngineer : CardEffect
{

    protected override void Start(){
        targetType = Card.Type.Building;
        targetTeam = TargetTeam.Enemy;
        needsTargetting = true;
    }
    //Mortar Strike - Deal {5} damage to a target building and {3} to adjacent buildings.
    public override int PerformEffect(GameData data)
    {
        GameObject go = data.target[0].gameObject;
        BuildingCardDisplay target;

        int effectValue1 = 5 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();
        int effectValue2 = 3 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();


        if (go.TryGetComponent(out target))
        {
            //Create a dictionary that maps field location (key) to buildingDisplay (value)
            Dictionary<int, BuildingCardDisplay> buildingsOnField = new Dictionary<int, BuildingCardDisplay>();

            if (target.playerNumber == GameManager.Instance.GetCurrentPlayer().number)
            {
                //Targeted friendly building (for some reason)
                foreach (var building in data.friendlyBuildings)
                {
                    buildingsOnField.Add(building.GetFieldLocation(), building);
                }
            }
            else
            {
                //Targeted enemy building. Add enemy buildings to Dictionary. 
                foreach (var building in data.enemyBuildings)
                {
                    buildingsOnField.Add(building.GetFieldLocation(), building);
                }
            }



            //Attack itself and adjacent buildings
            switch (target.GetFieldLocation())
            {
                //Attack location 1 and 2/4
                case 1:
                    target.SetCardHealth(target.GetCardHealth() - effectValue1);
                    buildingsOnField[2].SetCardHealth(buildingsOnField[2].GetCardHealth() - effectValue2);
                    buildingsOnField[4].SetCardHealth(buildingsOnField[4].GetCardHealth() - effectValue2);
                    break;
                //Attack location 2 and 1/5
                case 2:
                    target.SetCardHealth(target.GetCardHealth() - effectValue1);
                    buildingsOnField[1].SetCardHealth(buildingsOnField[1].GetCardHealth() - effectValue2);
                    buildingsOnField[5].SetCardHealth(buildingsOnField[5].GetCardHealth() - effectValue2);
                    break;
                //Attack location 3 and 4
                case 3:
                    target.SetCardHealth(target.GetCardHealth() - effectValue1);
                    buildingsOnField[4].SetCardHealth(buildingsOnField[4].GetCardHealth() - effectValue2);
                    break;
                //Attack location 4 and 1/3/5
                case 4:
                    target.SetCardHealth(target.GetCardHealth() - effectValue1);
                    buildingsOnField[1].SetCardHealth(buildingsOnField[1].GetCardHealth() - effectValue2);
                    buildingsOnField[3].SetCardHealth(buildingsOnField[3].GetCardHealth() - effectValue2);
                    buildingsOnField[5].SetCardHealth(buildingsOnField[5].GetCardHealth() - effectValue2);
                    break;
                //Attack location 5 and 2/4
                case 5:
                    target.SetCardHealth(target.GetCardHealth() - effectValue1);
                    buildingsOnField[2].SetCardHealth(buildingsOnField[2].GetCardHealth() - effectValue2);
                    buildingsOnField[4].SetCardHealth(buildingsOnField[4].GetCardHealth() - effectValue2);
                    break;
                default:
                    Debug.Log("Mechanical Engineer Effect failed. Invalid building index");
                    break;
            }
            Debug.Log("Architect worked");
        }
        else
        {
            Debug.Log("Mechanical Engineer Effect failed");
        }
        return 0;
    }
}
