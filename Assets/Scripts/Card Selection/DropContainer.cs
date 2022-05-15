using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


public class DropContainer : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        string[] accepted = {"UIStudentCard(Clone)", "UIBuildingCard(Clone)", "UIFacutlyCard(Clone)"};
        if (Array.IndexOf(accepted, eventData.pointerDrag.name) == -1){ return; }
        if (transform.childCount >= 20){ return; }

        var copy = Instantiate(eventData.pointerDrag, transform.position, transform.rotation);
        copy.GetComponent<RectTransform>().SetParent(this.transform);
        copy.GetComponent<DragAndDrop>().selected = true;

        RectTransform rec = GetComponent<RectTransform>();

        float cardHeight = 375f;

        float rows = Mathf.Ceil(transform.childCount / 2f);



        float new_height = (cardHeight * (rows + 0.5f));
        
        if (new_height > rec.sizeDelta.y){
            rec.sizeDelta = new Vector2(rec.sizeDelta.x, new_height);
        }


        transform.parent.gameObject.GetComponentInChildren<Text>().text =  "Deck: " + transform.childCount.ToString() + " / 20";
    }
}
