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

    public void OnValueChange(int value){
        CardsManager.instance.setCurrentDeck(value);
        deckGrid.GetComponent<DropContainer>().loadCurrentDeck();
    }
}
