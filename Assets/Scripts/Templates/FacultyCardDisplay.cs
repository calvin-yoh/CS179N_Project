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

	//Additional card information
	private string cardEffectName;

	// Use this for initialization
	void Start()
	{

	}

	public string GetCardEffectName(){
		return cardEffectName;
	}

	public override void SetUpInformation()
	{
		base.SetUpInformation();
		cardEffectName = card.effectName;
	}

	public override void SetUpInformationUI()
	{
		base.SetUpInformationUI();
		cardEffectName = card.effectName;
	}

	public override void DisplayInformation()
	{
		base.DisplayInformation();
		effectNameText.text = cardEffectName;
	}

	public void CopyInformation(FacultyCardDisplay oldCard){
		base.CopyInformation(oldCard);
		cardEffectName = oldCard.GetCardEffectName();
	}

	public override void HideCard(){
		base.HideCard();
		effectNameText.text = "";
	}
}