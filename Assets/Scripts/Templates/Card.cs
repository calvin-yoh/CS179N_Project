using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Card", menuName = "Cards/BuildingCard")]
public class Card : ScriptableObject
{
	public enum Major
	{
		Arts,
		Engineering,
		Staff,
		Athletics
	};

	public enum Type
	{
		Building,
		Student,
		Faculty
	}

	public new string name;
	public Major major;
	public Type type;

	public string effectName;
	public string effect;

	public Sprite artwork;

	public int health = 0;
	public int duration = 0;

	public void Print()
	{
		Debug.Log(name + ": " + effect);
	}

	public virtual void ApplyEffect()
	{ 
		// if (canActivateEffect){
		// 	Debug.Log(this.name + " activated its effect");
		// 	this.canActivateEffect = false;
		// }
		// else{
		// 	Debug.Log("Cannot activate " + this.name + "'s effect");
		// 	return;
		// }

	}
}