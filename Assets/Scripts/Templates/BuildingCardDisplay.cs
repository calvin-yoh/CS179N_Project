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

	// Use this for initialization
	void Start()
	{
		DisplayInformation();
	}

    protected override void DisplayInformation()
    {
		base.DisplayInformation();
		healthText.text = card.health.ToString();
	}

}