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

	//Additional card information
	private int cardHealth;
	private int cardArmor;

	// Use this for initialization
	void Start()
	{
	}

	public int GetCardHealth(){
		return cardHealth;
	}

	public int GetCardArmor(){
		return cardArmor;
	}

	public void SetCardArmor(int armor){
		cardArmor = armor;
		DisplayInformation();
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