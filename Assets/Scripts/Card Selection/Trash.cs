using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Trash : MonoBehaviour, IDropHandler
{
    public GameObject deckGrid;
    public void OnDrop(PointerEventData eventData){

        var card = eventData.pointerDrag;

        //continue only if parent of card is deckGrid
        if (card.transform.parent != deckGrid.transform) return;
        switch(card.GetComponent<DragAndDrop>().type){
            case Card.Type.Student:
                if(deckGrid.GetComponent<DropContainer>().studentCount > 0){
                    deckGrid.GetComponent<DropContainer>().studentCount--;
                }
                break;
            case Card.Type.Building:
                if(deckGrid.GetComponent<DropContainer>().buildingCount > 0){
                    deckGrid.GetComponent<DropContainer>().buildingCount--;
                }
                break;
            case Card.Type.Faculty:
                if(deckGrid.GetComponent<DropContainer>().facultyCount > 0){
                    deckGrid.GetComponent<DropContainer>().facultyCount--;
                }
                break;
            default:
                return;
        }

        if (!(card.transform.parent.gameObject.name == "Deck Grid")){ return; }
        var sound = GetComponent<AudioSource>();
        if(sound != null){
            sound.Play();
        }
        CardsManager.instance.removeCardFromDeck(card.GetComponent<CardDisplay>().GetCardName());
        Destroy(card);
    }
}
