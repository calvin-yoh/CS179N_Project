using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class CardDisplay : MonoBehaviour
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
    public Sprite backOfCard;

    public bool hasActivatedEffect = true;
    public bool inHand = false;
    public bool inPlay = false;
    public int playerNumber;
    [SerializeField] private GameObject glowEffect;

    //Current Card information
    private Card.Type cardType;
    private Card.Major cardMajor;
    private string cardName;
    private Sprite cardArtwork;
    private string cardEffectString;
    private bool isDistracted;
    public CardEffect cardEffectScript;

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

    public string GetCardName(){
        return cardName;
    }

    public Sprite GetCardArtwork(){
        return cardArtwork;
    }

    public string GetCardEffectString(){
        return cardEffectString;
    }

    public bool IsDistracted(){
        return isDistracted;
    }

    public void DistractCard()
    {
        isDistracted = true;
    }

    public void UnDistractCard()
    {
        isDistracted = false;
    }

    public CardEffect GetCardEffectScript()
    {
        return cardEffectScript;
    }

    #endregion

    public void ReactivateCard() // Lets the card be activated (again)
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
		return !hasActivatedEffect && inPlay;
	}

    public virtual void ActivateEffect(GameData gm){
        if (CanActivateEffect()){
            Debug.Log("Activating " + this.name + "'s effect");
            cardEffectScript.PerformEffect(gm);
            this.hasActivatedEffect = true;
            glowEffect.SetActive(false);
        }
    }

    // Sets up backend information for card during initalization

    public virtual void SetUpInformation()
    {
        cardType = card.type;
        cardMajor = card.major;
        cardName = card.name;
        cardArtwork = card.artwork;
        cardEffectString = card.effect;
        isDistracted = false;
        LoadCardEffectScript();
    }

    // Updates front end ui with backend information
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
        effectText.text = cardEffectString;

        artworkImage.sprite = cardArtwork;
    }

    public virtual void CopyInformation(CardDisplay oldCard){
        cardType = oldCard.GetCardType();
        cardMajor = oldCard.GetCardMajor();
        cardName = oldCard.GetCardName();
        cardArtwork = oldCard.GetCardArtwork();
        cardEffectString = oldCard.GetCardEffectString(); 
        isDistracted = oldCard.IsDistracted();   
    }

    public virtual void HideCard(){
        backgroundImage.sprite = backOfCard;
        nameText.text = "";
        effectText.text = "";
        glowEffect.SetActive(false);
    }

    public void LoadCardEffectScript()
    {
        if (card.effectScript != null)
        {
            string scriptName = card.effectScript.name;

            //We need to fetch the Type
            System.Type scriptType = System.Type.GetType(scriptName + ",Assembly-CSharp");
            //Now that we have the Type we can use it to Add Component
            gameObject.AddComponent(scriptType);

            CardEffect temp;
            if(this.TryGetComponent(out temp))
            {
                cardEffectScript = temp;
            }
        }
    }

    public void RemoveCardEffectScript()
    {
        cardEffectScript = null;
    }
}
