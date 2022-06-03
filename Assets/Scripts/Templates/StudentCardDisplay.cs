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
	public int cardDuration;
	private string cardEffectName;

	// Use this for initialization
	void Start()
	{
		
	}

    #region Getters/Setters
    public int GetCardDuration(){
		return cardDuration;
	}
	public string GetCardEffectName(){
		return cardEffectName;
	}

	public void SetDuration(int newDuration){
		cardDuration = newDuration;
		if (cardDuration <= 0)
		{
			RemoveCardFromPlay();
		}
		else
		{
			DisplayInformation();
		}
	}

	public void ChangeDurationBy(int value)
	{
		cardDuration += value;
		
		if (cardDuration <= 0)
		{
			RemoveCardFromPlay();
		}
		else
		{
			DisplayInformation();
		}
	}

    #endregion

    public override void SetUpInformation()
    {
        base.SetUpInformation();
		cardDuration = card.duration;
		cardEffectName = card.effectName;
    }

	public override void SetUpInformationUI()
	{
		base.SetUpInformationUI();
		cardDuration = card.duration;
		cardEffectName = card.effectName;
	}

	public override void DisplayInformation()
	{
		base.DisplayInformation();
		durationText.text = "Dur : " + cardDuration.ToString();
		effectNameText.text = cardEffectName.ToString();
	}

    public void CopyInformation(StudentCardDisplay oldCard)
    {
        base.CopyInformation(oldCard);
		cardDuration = oldCard.GetCardDuration();
		cardEffectName = oldCard.GetCardEffectName();
    }

	public void CopyInformationUI(StudentCardDisplay oldCard)
	{
		base.CopyInformationUI(oldCard);
		cardDuration = oldCard.GetCardDuration();
		cardEffectName = oldCard.GetCardEffectName();
	}

	public override void HideCard(){
		base.HideCard();
		durationText.text = "";
		effectNameText.text = "";
	}
}