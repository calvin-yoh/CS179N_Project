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
    public bool inHand = false;
    [SerializeField] private GameObject glowEffect;

    //Current Card information
    private Card.Type cardType;
    private Card.Major cardMajor;
    private string cardName;
    private Sprite cardArtwork;
    private string cardEffect;

    //public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {

    }

    #region Getters/Setters
    public Card.Major GetCardMajor()
    {
        return cardMajor;
    }

    public Card.Type GetCardType()
    {
        return cardType;
    }

    #endregion

    public void ResetCard()
    {
        Debug.Log("Card Reset");
        hasActivatedEffect = false;
        if (CanActivateEffect())
        {
            glowEffect.SetActive(true);
        }
        else
        {
            Debug.Log("Turning off glow");
            glowEffect.SetActive(false);
        }
    }

    public bool CanActivateEffect(){
		return !hasActivatedEffect && !inHand;
	}

    public virtual void ActivateEffect(){
        Debug.Log("Activating " + this.name + "'s effect");
        //card.ApplyEffect();
        this.hasActivatedEffect = true;
        glowEffect.SetActive(false);
    }

    public virtual void SetUpInformation()
    {
        cardType = card.type;
        cardMajor = card.major;
        cardName = card.name;
        cardArtwork = card.artwork;
        cardEffect = card.effect;
    }

    public virtual void DisplayInformation()
    {
        switch (cardMajor) {
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

        nameText.text = cardName;
        effectText.text = cardEffect;

        artworkImage.sprite = cardArtwork;
    }
}
