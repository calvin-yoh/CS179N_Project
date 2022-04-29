using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kalkatos.DottedArrow;

public class MouseInput : MonoBehaviour
{
    private static MouseInput _instance;
    [SerializeField] private Arrow arrow;

    public static MouseInput Instance {get {return _instance;}}
    public HandLayout hand;

    [SerializeField] private GameObject startObject;
    [SerializeField] private GameObject endObject;

    public enum State{
        Wait, DownField, DownHand, ApplyEffect
    }

    public State currState = State.Wait;

    private void Awake(){
        if (_instance != null && _instance != this){
            Destroy(this.gameObject);
        }
        else{
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
       CheckState();
       DoState();
    }

    void CheckState()
    {
        switch(currState)
        {
            case State.Wait:
                if (Input.GetMouseButtonDown(0))
                {
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Physics.Raycast(r, out hit);
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "Card")
                        {
                            GameObject cardHit = hit.collider.gameObject;
                            CardDisplay c = cardHit.GetComponent<CardDisplay>();
                            
                            //Show card details on the UI
                            CanvasManager.Instance.ShowCardDetails(c);

                            //Check if on field or in the hand
                            if (c.CanActivateEffect()){
                                startObject = hit.collider.gameObject;
                                currState = State.DownField;
                            }
                            else if (c.inHand){
                                startObject = hit.collider.gameObject;
                                currState = State.DownHand;
                            }
                        }
                        else
                        {
                            CanvasManager.Instance.HideCardDetails();
                            Debug.Log("Hit something, not card");
                        }
                    }
                }
                break;
            case State.DownField:
                if (Input.GetMouseButtonUp(0))
                {
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Physics.Raycast(r, out hit);
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "Card" && hit.collider.gameObject != startObject)
                        {
                            Debug.Log("Apply effect");
                            endObject = hit.collider.gameObject;
                            currState = State.ApplyEffect;
                        }
                        else
                        {
                            currState = State.Wait;
                        }
                    }
                    else
                    {
                        currState = State.Wait;
                    }
                }
                break;
            case State.DownHand:
                if (Input.GetMouseButtonUp(0))
                {
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Physics.Raycast(r, out hit);
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "Empty"){
                            Debug.Log(hit.collider.gameObject.name);
                            Card newCard = startObject.GetComponent<CardDisplay>().card;
                            EmptyBoardSlot slot = hit.collider.gameObject.GetComponent<EmptyBoardSlot>();
                            if (newCard.type == slot.GetCardType()){
                                slot.PlaceCard(newCard);
                                hand.RemoveCard(newCard);
                            }
                            else{
                                Debug.Log("Card type does not match");
                            }
                        }
                    }
                    currState = State.Wait;
                }
                break;
            case State.ApplyEffect:
                //EffectSystem add effect. Pass in both startObject and endObject
                currState = State.Wait;
                break;
        }
    }

    void DoState()
    {
        switch(currState)
        {
            case State.Wait:
                if(arrow.isActive)
                {
                    arrow.Deactivate();
                }
                startObject = null;
                endObject = null;
                break;
            case State.DownField:
                // Debug.Log(arrow.gameObject.activeInHierarchy);
                if(!arrow.isActive)
                {
                    arrow.SetupAndActivate(startObject.transform);
                }
                break;
            case State.DownHand:
                if(!arrow.isActive)
                {
                    arrow.SetupAndActivate(startObject.transform);
                }
                break;
            case State.ApplyEffect:

                break;
            default:
                break;
        }
    }



    GameObject checkObjectClicked(){
        if (Input.GetMouseButtonDown(0)){
            // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            // RaycastHit hit = Physics.Raycast(mousePos, Vector2.zero);
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(r, out hit);
            if (hit.collider != null){
                if (hit.collider.tag == "Card"){
                    GameObject cardHit = hit.collider.gameObject;
                    CardDisplay c = cardHit.GetComponent<CardDisplay>();

                    if (c.CanActivateEffect()){
                        arrow.SetupAndActivate(cardHit.transform);
                    }
                }
                // Debug.Log("Clicked on " + hit.collider.gameObject.name);
                if(startObject != null){
                    arrow.Deactivate();
                }
                return hit.collider.gameObject;
            }
        }
        return null;
    }
}
