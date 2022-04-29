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

	// Use this for initialization
	void Start()
	{
	}

	public override void SetUpInformation()
	{
		base.SetUpInformation();
		cardHealth = card.health;
	}


	public override void DisplayInformation()
    {
		base.DisplayInformation();
		healthText.text = "HP : " + cardHealth.ToString();
	}
}