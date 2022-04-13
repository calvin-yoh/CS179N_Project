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

	public new string name;
	public Major major;
	public string effect;

	public Sprite artwork;

	//public int health;

	public void Print()
	{
		Debug.Log(name + ": " + effect);
	}

	public virtual void ApplyEffect()
	{ 

	}
}