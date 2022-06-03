using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckSwap : MonoBehaviour
{
    public GameObject deckGrid;
    private TMP_Dropdown deckSelector; 

    public void Start(){
        deckSelector = GetComponent<TMP_Dropdown>();

        deckSelector.ClearOptions();
        for (int i = 0; i < CardsManager.instance.DeckData.decks.Count; i++){
            deckSelector.options.Add(new TMP_Dropdown.OptionData("Deck " + (i + 1)));
        }

        deckSelector.value = CardsManager.instance.DeckData.currentDeck;
        deckSelector.RefreshShownValue();

        deckGrid.GetComponent<DropContainer>().loadCurrentDeck();
    }

    private void AddRandomBuildingCard(){
        var cards = CardsManager.instance.getAllCards();
        var buildings = new List<Card>();
        foreach(var card in cards){
            if (card.type == Card.Type.Building){
                buildings.Add(card);
            }
        }
        //get random building card
        var randomIndex = Random.Range(0, buildings.Count);
        var randomCard = buildings[randomIndex];
        var temp = Instantiate(CardsManager.instance.getCardPrefab(randomCard.type));
        temp.GetComponent<CardDisplay>().card = randomCard;
        temp.GetComponent<CardDisplay>().SetUpInformationUI();
        temp.GetComponent<CardDisplay>().DisplayInformation();
        deckGrid.GetComponent<DropContainer>().addCard(temp);
    }

    public void OnValueChange(int value){
        if(deckGrid.GetComponent<DropContainer>().buildingCount < 1){
            AddRandomBuildingCard();
        }
        
        CardsManager.instance.setCurrentDeck(value);
        deckGrid.GetComponent<DropContainer>().loadCurrentDeck();
    }
}
