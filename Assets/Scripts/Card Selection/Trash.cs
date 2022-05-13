using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Trash : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){

        var card = eventData.pointerDrag;
        string[] accepted = {"UIStudentCard(Clone)(Clone)", "UIBuildingCard(Clone)(Clone)", "UIFacutlyCard(Clone)(Clone)"};
        if (Array.IndexOf(accepted, card.name) == -1){ return; }

        if (!card.GetComponent<DragAndDrop>().selected){ return; }

        transform.parent.gameObject.GetComponentInChildren<Text>().text =  "Deck: " + (card.transform.parent.childCount - 1).ToString() + " / 20";
        Destroy(card);
    }
}
