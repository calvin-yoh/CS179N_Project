using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckOptionsHandler : MonoBehaviour
{
    public TMP_Dropdown decks;
    public GameObject deckGrid;
    private TMP_Dropdown deckOptions;

    private enum Options
    {
        browse,
        create,
        delete
    }

    public void Start(){
        deckOptions = GetComponentInChildren<TMP_Dropdown>();
    }

    public void OnValueChange(int value){
        if (value == (int)Options.browse){
        }
        else if (value == (int)Options.create){
            addEmptyDeck();
        }
        else if (value == (int)Options.delete){
            deleteCurrentDeck();
        }
    }

    public void addEmptyDeck(){
        CardsManager.instance.addDeck();
        int index = CardsManager.instance.DeckData.decks.Count - 1;

        decks.options.Add(new TMPro.TMP_Dropdown.OptionData("Deck " + (index + 1)));
        decks.value = index;
        deckOptions.value = (int)Options.browse;
        deckOptions.RefreshShownValue();
    
        CardsManager.instance.setCurrentDeck(index);
        deckGrid.GetComponent<DropContainer>().loadCurrentDeck();
    }

    public void deleteCurrentDeck(){
        if (CardsManager.instance.DeckData.decks.Count <= 1){
            return;
        }

        CardsManager.instance.removeDeck(decks.value);
        decks.options.RemoveAt(decks.value);

        deckOptions.value = (int)Options.browse;
        deckOptions.RefreshShownValue();

        decks.value = 0;

        foreach(var option in decks.options){
            option.text = "Deck " + (decks.options.IndexOf(option) + 1);
        }
        decks.RefreshShownValue();
        deckGrid.GetComponent<DropContainer>().loadCurrentDeck();
    }
}
