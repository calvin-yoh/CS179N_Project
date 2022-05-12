using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rect;
    private CanvasGroup canvasGroup;

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
        var copy = Instantiate(this, transform.position, transform.rotation);
        copy.GetComponent<RectTransform>().SetParent(transform);

        rect = copy.GetComponent<RectTransform>();
        canvasGroup = copy.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0.6f;
    }

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData){
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerUp(PointerEventData eventData){
        Destroy(rect.gameObject);
    }
}

