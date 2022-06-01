using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingCardDisplay : CardDisplay
{
	/*
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI effectText;

	public Image artworkImage;
	*/

	public TextMeshProUGUI healthText;

	private int fieldLocation = 0;

	//Additional card information
	private int BUILDING_MAX_HEALTH;
	private int cardHealth;
	private int cardArmor;

	// Use this for initialization
	void Start()
	{
		BUILDING_MAX_HEALTH = cardHealth;
	}

	public int GetCardHealth(){
		return cardHealth;
	}

	public void SetCardHealth(int newHealth)
	{
		cardHealth = newHealth;
		if (cardHealth <= 0){
			RemoveCardFromPlay();
		}
	}

	public void DamageBuilding(int damageTaken){
		if (cardArmor > 0){
			if (cardArmor > damageTaken){
				cardArmor -= damageTaken;
				return;
			}
			else{
				damageTaken -= cardArmor;
				cardArmor = 0;
			}
		}

		cardHealth -= damageTaken;
		if (cardHealth <= 0){
			RemoveCardFromPlay();
			GameManager.Instance.CheckGameEnded(playerNumber);
		}
	}

	public void HealBuilding(int healthHealed){
		cardHealth += healthHealed;
		if (cardHealth > BUILDING_MAX_HEALTH){
			cardHealth = BUILDING_MAX_HEALTH;
		}
	}

	public int GetCardArmor(){
		return cardArmor;
	}

	public void SetCardArmor(int armor){
		cardArmor = armor;
		DisplayInformation();
	}

	public void SetFieldLocation(int loc)
	{
		fieldLocation = loc;
	}

	public int GetFieldLocation()
	{
		return fieldLocation;
	}

	public override void SetUpInformation()
	{
		base.SetUpInformation();
		cardHealth = card.health;
		cardArmor = 0;
	}


	public override void DisplayInformation()
    {
		base.DisplayInformation();
		if (cardArmor == 0){
			healthText.text = "HP : " + cardHealth.ToString();
		}
		else{
			healthText.text = "HP : " + cardHealth.ToString() + " + " + $"<color=#A9A9A9>{cardArmor.ToString()}</color>";
		}
	}

	public void CopyInformation(BuildingCardDisplay oldCard){
		base.CopyInformation(oldCard);
		cardHealth = oldCard.GetCardHealth();
		cardArmor = oldCard.GetCardArmor();
	}

	public override void HideCard(){
		base.HideCard();
		healthText.text = "";
	}
}