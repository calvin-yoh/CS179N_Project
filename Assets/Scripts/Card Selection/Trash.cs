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


        switch(card.name){
            case "UIStudentCard(Clone)(Clone)":
                if (deckGrid.GetComponent<DropContainer>().studentCount <= 0) return;
                deckGrid.GetComponent<DropContainer>().studentCount--;
                break;   
            case "UIBuildingCard(Clone)(Clone)":
                if (deckGrid.GetComponent<DropContainer>().buildingCount <= 0) return;
                deckGrid.GetComponent<DropContainer>().buildingCount--;
                break;
            case "UIFacultyCard(Clone)(Clone)":
                if (deckGrid.GetComponent<DropContainer>().facultyCount <= 0) return;
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
