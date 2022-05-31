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


        switch(card.GetComponent<DragAndDrop>().type){
            case Card.Type.Student:
                deckGrid.GetComponent<DropContainer>().studentCount--;
                break;
            case Card.Type.Building:
                deckGrid.GetComponent<DropContainer>().buildingCount--;
                break;
            case Card.Type.Faculty:
                deckGrid.GetComponent<DropContainer>().facultyCount--;
                break;
        
            default:
                return;
        }

        if (!(card.transform.parent.gameObject.name == "Deck Grid")){ return; }

        deckGrid.transform.parent.gameObject.GetComponentInChildren<Text>().text =  "Deck: " + (deckGrid.transform.childCount - 1).ToString() + " / 20";
        Destroy(card);
    }
}
