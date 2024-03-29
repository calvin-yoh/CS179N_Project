using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;

public abstract class CardDisplay : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI effectText;

    public AudioSource activateEffectSound;

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
    public bool inDeck = false;
    public int playerNumber;
    public int turnsInPlay;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject ActivateEffectButton;
    [SerializeField] private GameObject distractedImage;

    public bool activateButtonWasPressed;

    //Current Card information
    private Card.Type cardType;
    private Card.Major cardMajor;
    private string cardName;
    private Sprite cardArtwork;
    private string cardEffectString;
    private bool isDistracted;
    public CardEffect cardEffectScript;

    //Turn by turn Card info
    private int effectValueModifier = 0;

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

    public string GetCardName() {
        return cardName;
    }

    public Sprite GetCardArtwork() {
        return cardArtwork;
    }

    public string GetCardEffectString() {
        return cardEffectString;
    }

    public bool IsDistracted() {
        return isDistracted;
    }

    public void DistractCard()
    {
        distractedImage.SetActive(true);
        isDistracted = true;
    }

    public void UnDistractCard()
    {
        distractedImage.SetActive(false);
        isDistracted = false;
    }

    public CardEffect GetCardEffectScript()
    {
        return cardEffectScript;
    }

    public int GetEffectValueModifier()
    {
        return effectValueModifier;
    }

    public void SetEffectValueModifier(int val)
    {
        effectValueModifier = val;
        UpdateEffectString();
        DisplayInformation();
    }

    public void IncreaseTurnCount(){
        turnsInPlay++;
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
            if (isDistracted) {
                hasActivatedEffect = true;
                UnDistractCard();
            }
            Debug.Log("Turning off glow");
            glowEffect.SetActive(false);
        }
    }

    public bool CanActivateEffect() {
        return !hasActivatedEffect && inPlay && !isDistracted;
    }

    public virtual int ActivateEffect(GameData gm) {
        if (CanActivateEffect()) {
            CardEffect temp;
            if (TryGetComponent(out temp))
            {
                Debug.Log("Activating " + this.name + "'s effect");
                this.hasActivatedEffect = true;

                //sound effect for activated card
                activateEffectSound.Play();

                glowEffect.SetActive(false);
                return cardEffectScript.PerformEffect(gm);
            }
        }
        return -1;
    }

    // Sets up backend information for card during initalization

    public virtual void SetUpInformation()
    {
        cardType = card.type;
        cardMajor = card.major;
        cardName = card.name;
        cardArtwork = card.artwork;
        isDistracted = false;
        turnsInPlay = 0;
        UpdateEffectString();
        LoadCardEffectScript();
    }

    public virtual void SetUpInformationUI()
    {
        cardType = card.type;
        cardMajor = card.major;
        cardName = card.name;
        cardArtwork = card.artwork;
        isDistracted = false;
        turnsInPlay = 0;
        UpdateEffectString();
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

    public virtual void DisplayInformationUI()
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

    public virtual void CopyInformation(CardDisplay oldCard) {
        cardType = oldCard.GetCardType();
        cardMajor = oldCard.GetCardMajor();
        cardName = oldCard.GetCardName();
        cardArtwork = oldCard.GetCardArtwork();
        cardEffectString = oldCard.GetCardEffectString();
        isDistracted = oldCard.IsDistracted();
        UpdateEffectString();
        LoadCardEffectScript();
    }

    public virtual void CopyInformationUI(CardDisplay oldCard)
    {
        cardType = oldCard.GetCardType();
        cardMajor = oldCard.GetCardMajor();
        cardName = oldCard.GetCardName();
        cardArtwork = oldCard.GetCardArtwork();
        cardEffectString = oldCard.GetCardEffectString();
        isDistracted = oldCard.IsDistracted();
    }

    public virtual void HideCard() {
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
            if (this.TryGetComponent(out temp))
            {
                cardEffectScript = temp;
            }
            
        }
    }

    public void RemoveCardEffectScript()
    {
        cardEffectScript = null;
        CardEffect temp;
        if (gameObject.TryGetComponent(out temp))
        {
            Destroy(temp);
            Debug.Log("Destory effect script");
        }
    }

    public void RemoveEffectModifier()
    {
        effectValueModifier = 0;
        UpdateEffectString();
    }

    public void RemoveCardFromPlay() 
    {
        ResetCardToPlaceholder();
        Player temp = GameManager.Instance.GetPlayerWithNum(playerNumber);

        if (temp != null)
        {
            EventsManager em = temp.GetEventsManager();
            em.CallOnCardRemovedFromField(this);
        }
        this.gameObject.SetActive(false);
    }

    public void ResetCardToPlaceholder()
    {
        card = null;

        hasActivatedEffect = false;
        inHand = false;
        inPlay = false;

        //Current Card information
        cardType = Card.Type.None;
        cardMajor = Card.Major.None;
        cardName = null;
        cardArtwork = null;
        cardEffectString = null;
        isDistracted = false;
        cardEffectScript = null;
        turnsInPlay = 0;
        //Turn by turn Card info
        effectValueModifier = 0;
        RemoveCardEffectScript();
    }

    public void UpdateEffectString()
    {
        string text = card.effect;
        int x = 0;
        StringBuilder sb = new StringBuilder();
        StringBuilder updatedString = new StringBuilder();

        while (x < text.Length)
        {
            if (text[x].Equals('{'))
            {
                x++;
                
                //Find the entire damage number
                while (x < text.Length && !text[x].Equals('}'))
                {
                    sb.Append(text[x]);
                    x++;
                }
                //End
                x++;

                //Update the damage number
                int tempDamage;
                if (!int.TryParse(sb.ToString(), out tempDamage))
                {
                    Debug.LogError(card.name + " has an invalid effect text with dynamic damage.Check the scriptable object.");
                    return;
                }

                if (GetEffectValueModifier() != 0)
                {
                    tempDamage += GetEffectValueModifier();
                    updatedString.Append($"<b>*{tempDamage}*</b>");
                }
                else
                {
                    updatedString.Append($"<b>{tempDamage}</b>");
                }
                

                //End
                sb.Clear();
            }
            else
            {
                updatedString.Append(text[x]);
                x++;
            }
        }

        cardEffectString = updatedString.ToString();
    }

    public void EnableEffectButton(){
        ActivateEffectButton.SetActive(true);
    }
    
    public void DisableEffectButton(){
        ActivateEffectButton.SetActive(false);
    }
}
