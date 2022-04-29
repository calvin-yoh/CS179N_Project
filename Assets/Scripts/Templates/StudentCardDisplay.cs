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

	//Additional card information
	private int cardDuration;
	private string cardEffectName;

	// Use this for initialization
	void Start()
	{
	}

	public void ChangeDurationBy(int value)
	{
		cardDuration += value;
	}

    public override void SetUpInformation()
    {
        base.SetUpInformation();
		cardDuration = card.duration;
		cardEffectName = card.effectName;
    }

    public override void DisplayInformation()
	{
		base.DisplayInformation();
		durationText.text = "Dur : " + cardDuration.ToString();
		effectNameText.text = cardEffectName.ToString();
	}
}