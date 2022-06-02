using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

    // [SerializeField] private Arrow arrow;
    [SerializeField] private Player player;

    [SerializeField] private GameObject startObject;
    [SerializeField] private GameObject endObject;


    private List<CardDisplay> targets = new List<CardDisplay>();

    private CanvasManager canvasInstance;

    public bool activateButtonWasPressed;
    private int currNumTargets;
    private EventsManager ev;

    //temp variables
    private bool tempPlacedCard;

    public enum State{
        Wait, DownHand, ApplyEffect, WaitForButton, ChoosingTargets, ChoseTarget
    }

    public State currState = State.Wait;

    void Start(){
        canvasInstance = CanvasManager.Instance;
        ev = player.GetEventsManager();
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
                            Debug.Log("Clicked on a card");
                            GameObject cardHit = hit.collider.gameObject;
                            CardDisplay c = cardHit.GetComponent<CardDisplay>();
                            
                            //Show card details on the UI
                            if (c.playerNumber == player.number || c.inPlay){    // Prevents player from reading opponents hand
                                CanvasManager.Instance.ShowCardDetails(c);
                            }

                            //Check if on field or in the hand
                            if ( c.playerNumber == player.number){
                                if (c.CanActivateEffect()){
                                    startObject = hit.collider.gameObject;
                                    c.EnableEffectButton();
                                    currState = State.WaitForButton;
                                }
                                else if (c.inHand){
                                    startObject = hit.collider.gameObject;
                                    currState = State.DownHand;
                                }
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
                            CardDisplay downHandCardDisplay = startObject.GetComponent<CardDisplay>();
                            Card newCard = downHandCardDisplay.card;

                            EmptyBoardSlot slot = hit.collider.gameObject.GetComponent<EmptyBoardSlot>();
                            if (!tempPlacedCard && newCard.type == slot.GetCardType() && slot.GetField() == player.GetField()){
                                tempPlacedCard = true;
                                ev.CallOnCardPlayedFromHand(downHandCardDisplay);
                                player.PlaceCard(slot.GetIndex(), downHandCardDisplay);
                            }
                            else{
                                Debug.Log("Card type does not match");
                            }
                        }
                    }
                    currState = State.Wait;
                }
                break;
            case State.WaitForButton:
                if (!activateButtonWasPressed && Input.GetMouseButtonDown(0))
                {
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Physics.Raycast(r, out hit);
                    if (hit.collider != null && hit.collider.tag != "EffectButton")
                    {
                        Debug.Log(hit.collider.tag);
                        CardDisplay x = startObject.GetComponent<CardDisplay>();
                        x.DisableEffectButton();
                        currState = State.Wait;
                    }
                }
                
                break;
            case State.ChoosingTargets:
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
                            targets.Add(hit.collider.gameObject.GetComponent<CardDisplay>());
                            currNumTargets -= 1;
                            currState = State.ChoseTarget;
                        }
                    }
                }
                break;
            case State.ChoseTarget:
                if(currNumTargets > 0)
                {
                    currState = State.ChoosingTargets;
                }
                else
                {
                    currState = State.ApplyEffect;
                }
                break;

            case State.ApplyEffect:

                Player enemy = GameManager.Instance.GetOpposingPlayer();
                CardDisplay self = startObject.GetComponent<CardDisplay>();
                // List<CardDisplay> target = new List<CardDisplay>();

                /*
                if (endObject != null){
                    target.Add(endObject.GetComponent<CardDisplay>());
                }
                */

                List<BuildingCardDisplay> friendlyBuildings = player.GetField().GetActiveBuildingCards();
                List<BuildingCardDisplay> enemyBuildings = enemy.GetField().GetActiveBuildingCards();

                List<FacultyCardDisplay> friendlyFaculties = player.GetField().GetActiveFacultyCards();
                List<FacultyCardDisplay> enemyFaculties = enemy.GetField().GetActiveFacultyCards(); ;

                List<StudentCardDisplay> friendlyStudents = player.GetField().GetActiveStudentCards();
                List<StudentCardDisplay> enemyStudents = enemy.GetField().GetActiveStudentCards(); 

                DeckLayout friendlyDeck = player.GetDeck();
                DeckLayout enemyDeck = enemy.GetDeck();

                HandLayout friendlyHand = player.GetHand();
                HandLayout enemyHand = enemy.GetHand();
                Player friendly = GameManager.Instance.GetCurrentPlayer();
                Player enemyPlayer = GameManager.Instance.GetOpposingPlayer();

                GameData gd = new GameData(friendlyBuildings, enemyBuildings,
                     friendlyFaculties, enemyFaculties,
                     friendlyStudents, enemyStudents,
                     friendlyDeck, enemyDeck,
                     friendlyHand, enemyHand,
                     targets, self,
                     friendly, enemy
                    );

                CardEffect temp;

                if(startObject.TryGetComponent(out temp))
                {
                    self.ActivateEffect(gd); 
                }
                currState = State.Wait;
                break;
        }
    }

    void DoState()
    {
        switch(currState)
        {
            case State.Wait:
                canvasInstance.DeactivateArrow();
                startObject = null;
                endObject = null;
                tempPlacedCard = false;
                if(targets.Count != 0)
                {
                    targets.Clear();
                }
                currNumTargets = 0;
                activateButtonWasPressed = false;
                break;
            case State.DownHand:
                 canvasInstance.SetUpArrow(startObject.transform);
                break;
            case State.ChoosingTargets:
                // Debug.Log(arrow.gameObject.activeInHierarchy);
                canvasInstance.SetUpArrow(startObject.transform);
                break;
            case State.ChoseTarget:
                canvasInstance.DeactivateArrow();
                break;
            case State.ApplyEffect:

                break;
            default:
                break;
        }
    }

    //Referenced in a button event
    public void PressedActivateCardButton()
    {
        CardEffect tempCard;

        if(startObject.TryGetComponent(out tempCard))
        {
            startObject.GetComponent<CardDisplay>().DisableEffectButton();
            activateButtonWasPressed = true;
            if(tempCard.numTargets == 0)
            {
                currState = State.ApplyEffect;
            }
            else
            {
                currNumTargets = tempCard.numTargets;
                currState = State.ChoosingTargets;
            }
        }
    }

    // GameObject checkObjectClicked(){
    //     if (Input.GetMouseButtonDown(0)){
    //         // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         // Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
    //         // RaycastHit hit = Physics.Raycast(mousePos, Vector2.zero);
    //         Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hit;
    //         Physics.Raycast(r, out hit);
    //         if (hit.collider != null){
    //             if (hit.collider.tag == "Card"){
    //                 GameObject cardHit = hit.collider.gameObject;
    //                 CardDisplay c = cardHit.GetComponent<CardDisplay>();

    //                 if (c.CanActivateEffect()){
    //                     arrow.SetupAndActivate(cardHit.transform);
    //                 }
    //             }
    //             // Debug.Log("Clicked on " + hit.collider.gameObject.name);
    //             if(startObject != null){
    //                 arrow.Deactivate();
    //             }
    //             return hit.collider.gameObject;
    //         }
    //     }
    //     return null;
    // }
}
