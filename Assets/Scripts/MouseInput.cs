using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

    // [SerializeField] private Arrow arrow;
    [SerializeField] private Player player;

    [SerializeField] private GameObject startObject;
    [SerializeField] private GameObject endObject;

    private CanvasManager canvasInstance;

    public enum State{
        Wait, DownField, DownHand, ApplyEffect
    }

    public State currState = State.Wait;

    void Start(){
        canvasInstance = CanvasManager.Instance;
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
                                    currState = State.DownField;
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
                            if (newCard.type == slot.GetCardType() && slot.GetField() == player.GetField()){
                                player.PlaceCard(slot.GetIndex(), newCard);
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

                Player enemy = GameManager.Instance.GetOpposingPlayer();
                CardDisplay self = startObject.GetComponent<CardDisplay>();
                List<CardDisplay> target = new List<CardDisplay>();
                target.Add(endObject.GetComponent<CardDisplay>());

                List<BuildingCardDisplay> friendlyBuildings = player.GetField().GetBuildingCards();
                List<BuildingCardDisplay> enemyBuildings = enemy.GetField().GetBuildingCards();

                List<FacultyCardDisplay> friendlyFaculties = player.GetField().GetFacultyCards();
                List<FacultyCardDisplay> enemyFaculties = enemy.GetField().GetFacultyCards(); ;

                List<StudentCardDisplay> friendlyStudents = player.GetField().GetStudentCards();
                List<StudentCardDisplay> enemyStudents = enemy.GetField().GetStudentCards(); 

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
                     target, self,
                     friendly, enemy
                    );

                CardEffect temp;

                if(startObject.TryGetComponent(out temp))
                {
                    self.ActivateEffect(gd);
                    // if (!self.hasActivatedEffect)
                    // {
                    //     temp.PerformEffect(gd);
                    //     self.hasActivatedEffect = true;
                    // }    
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
                break;
            case State.DownField:
                // Debug.Log(arrow.gameObject.activeInHierarchy);
                canvasInstance.SetUpArrow(startObject.transform);
                break;
            case State.DownHand:
                 canvasInstance.SetUpArrow(startObject.transform);

                break;
            case State.ApplyEffect:

                break;
            default:
                break;
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
