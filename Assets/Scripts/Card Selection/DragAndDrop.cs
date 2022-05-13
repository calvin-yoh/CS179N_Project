using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rect;
    private CanvasGroup canvasGroup;
    public bool selected = false;

    public void OnPointerDown(PointerEventData eventData){
        var canvas_transform = this.transform.parent.parent.parent;
        var copy = Instantiate(this, canvas_transform.position, canvas_transform.rotation, canvas_transform);
        
        rect = copy.GetComponent<RectTransform>();
        canvasGroup = copy.GetComponent<CanvasGroup>();

        rect.sizeDelta = new Vector2(200f, 300f);
        rect.anchoredPosition = eventData.position;

        copy.transform.SetAsLastSibling();

        GetComponent<CanvasGroup>().alpha = 0.6f;
    }

    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData){
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerUp(PointerEventData eventData){
        Destroy(rect.gameObject);
        GetComponent<CanvasGroup>().alpha = 1f;
    }
}


