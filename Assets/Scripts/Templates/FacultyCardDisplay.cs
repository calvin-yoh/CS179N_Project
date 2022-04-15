using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FacultyCardDisplay : CardDisplay
{
	/*
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI effectText;

	public Image artworkImage;
	*/

	public TextMeshProUGUI effectNameText;

	// Use this for initialization
	void Start()
	{
		DisplayInformation();
	}

	protected override void DisplayInformation()
	{
		base.DisplayInformation();
		effectNameText.text = card.effectName.ToString();
	}
}