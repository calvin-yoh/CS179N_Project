using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropContainer : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null){
            var copy = Instantiate(eventData.pointerDrag, transform.position, transform.rotation);
            copy.GetComponent<RectTransform>().SetParent(this.transform);
        }


        RectTransform rec = GetComponent<RectTransform>();

        float cardHeight = 200f;

        float rows = Mathf.Ceil(transform.childCount / 2f);



        float new_height = (cardHeight * rows) + 300;
        
        if (new_height > rec.sizeDelta.y){
            rec.sizeDelta = new Vector2(350, new_height);

            rec.position = new Vector3(rec.position.x, -(new_height / 2), rec.position.z);
        }
    }
}
