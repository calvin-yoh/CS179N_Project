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

	public CardEffect effectScript;

	public void Print()
	{
		Debug.Log(name + ": " + effect);
	}

	public void PerformEffect(GameData gd)
	{
		effectScript.PerformEffect(gd);
	}
}