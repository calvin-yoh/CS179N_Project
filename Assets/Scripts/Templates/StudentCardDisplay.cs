using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StudentCardDisplay : CardDisplay
{
	/*
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI effectText;

	public Image artworkImage;
	*/

	public TextMeshProUGUI durationText;
	public TextMeshProUGUI effectNameText;

	// Use this for initialization
	void Start()
	{
		DisplayInformation();
	}

	protected override void DisplayInformation()
	{
		base.DisplayInformation();
		durationText.text = "Dur : " + card.duration.ToString();
		effectNameText.text = card.effectName.ToString();
	}
}