using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI effectText;

    public Image artworkImage;
    public Image backgroundImage;

    public Sprite artBackground;
    public Sprite engineeringBackground;
    public Sprite staffBackground;
    public Sprite athleticBackground;

    public bool hasActivatedEffect;
    public bool inHand;

    //public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        DisplayInformation();
        inHand = false;
        hasActivatedEffect = false;
    }


    public bool CanActivateEffect(){
		return !hasActivatedEffect && !inHand;
	}

    public virtual void ActivateEffect(){
        Debug.Log("Activating " + this.name + "'s effect");
        card.ApplyEffect();
        this.hasActivatedEffect = true;
    }

    protected virtual void DisplayInformation()
    {
        switch (card.major) {
            case Card.Major.Arts:
                backgroundImage.sprite = artBackground;
                break;
            case Card.Major.Engineering:
                backgroundImage.sprite = engineeringBackground;
                break;
            case Card.Major.Athletics:
                backgroundImage.sprite = athleticBackground;
                break;
            case Card.Major.Staff:
                backgroundImage.sprite = staffBackground;
                break;
            default:
                Debug.LogError("Invalid major for card");
                break;
        }

        nameText.text = card.name;
        effectText.text = card.effect;

        artworkImage.sprite = card.artwork;
    }
}
