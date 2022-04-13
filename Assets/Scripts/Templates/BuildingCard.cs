using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/BuildingCard")]
public class BuildingCard : Card
{
	public int health;

    public override void ApplyEffect()
    {
        Debug.Log("Activating " + name + "'s effect.");
    }
}