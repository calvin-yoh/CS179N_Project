using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingCardDisplay : MonoBehaviour
{
	public BuildingCard card;

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI effectText;

	public Image artworkImage;

	public TextMeshProUGUI healthText;

	// Use this for initialization
	void Start()
	{
		nameText.text = card.name;
		effectText.text = card.effect;

		artworkImage.sprite = card.artwork;

		healthText.text = card.health.ToString();
	}

}