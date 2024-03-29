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

	public Image buildingStatusImage;

	[SerializeField] private Sprite weakenedIcon;
	[SerializeField] private Sprite immuneIcon;

	private int fieldLocation = 0;

	private bool isWeakened;
	private bool isImmune;

	//Additional card information
	private int BUILDING_MAX_HEALTH;
	private int cardHealth;
	private int cardArmor;

	// Use this for initialization
	void Start()
	{
		
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

	public void SetBuildingWeaken(bool weaken)
	{
		isWeakened = weaken;
		DisplayStatusImage();
	}

	public void ResetWeaken()
	{
		isWeakened = false;
		
	}

	public void SetBuildingImmunity(bool immunity)
	{
		isImmune = immunity;
	}

	public void ResetImmunity()
	{
		isImmune=false;
	}

	public void DisplayStatusImage()
	{
		if (isImmune)
		{
			buildingStatusImage.gameObject.SetActive(true);
			buildingStatusImage.sprite = immuneIcon;
		}
		else if (isWeakened)
		{
			buildingStatusImage.gameObject.SetActive(true);
			buildingStatusImage.sprite = weakenedIcon;
		}
		else
        {
			buildingStatusImage.gameObject.SetActive(false);
		}
	}

	public void DamageBuilding(int damageTaken){

		int realDamage = damageTaken;
		if (isImmune)
		{
			return;
		}
		if (isWeakened)
		{
			realDamage *= 2;
		}
		
		if (cardArmor > 0){
			if (cardArmor > realDamage)
			{
				cardArmor -= realDamage;
				return;
			}
			else{
				realDamage -= cardArmor;
				cardArmor = 0;
			}
		}

		cardHealth -= realDamage;
		DisplayInformation();
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
		BUILDING_MAX_HEALTH = cardHealth;
		cardArmor = 0;
	}

	public override void SetUpInformationUI()
	{
		base.SetUpInformationUI();
		cardHealth = card.health;
		BUILDING_MAX_HEALTH = cardHealth;
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

	public override void DisplayInformationUI()
    {
		base.DisplayInformationUI();
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

	public void CopyInformationUI(BuildingCardDisplay oldCard)
	{
		base.CopyInformationUI(oldCard);
		cardHealth = oldCard.GetCardHealth();
		cardArmor = oldCard.GetCardArmor();
	}

	public override void HideCard(){
		base.HideCard();
		healthText.text = "";
	}

	public void ResetBuildingBools()
	{
		ResetWeaken();
	}
}