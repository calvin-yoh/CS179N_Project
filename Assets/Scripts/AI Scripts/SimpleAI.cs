using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : Player
{
    public bool isDrawPhase = true;
    public bool isPlaceCardsPhase = false;
    public bool isActivateEffectPhase = false;
    public bool isEndTurnPhase = false;

    // Start is called before the first frame update
    void Start()
    {  
        isAI = true;
        isDrawPhase = true;
        isPlaceCardsPhase = false;
        isActivateEffectPhase = false;
        isEndTurnPhase = false;

        // hand = new List<Card>(20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBools()
    {
        isDrawPhase = true;
        isPlaceCardsPhase = false;
        isActivateEffectPhase = false;
        isEndTurnPhase = false;
        numStudentCardsCanPlace = 1;
        numFacultyCardsCanPlace = 1;
    }


    public IEnumerator PlayAITurn()
    {
        ResetBools();
        StartCoroutine(DrawPhase());
        yield return new WaitUntil(() => isPlaceCardsPhase);
        StartCoroutine(PlaceCardsPhase());
        yield return new WaitUntil(() => isActivateEffectPhase);
        StartCoroutine(ActivateEffectPhase());
        yield return new WaitUntil(() => isEndTurnPhase);

        yield return new WaitForSeconds(1f);
        Debug.Log("End Turn");
        EndTurn();
    }

    public IEnumerator DrawPhase()
    {
        Debug.Log("Drawing a card");
        
        //DrawCard();
        StartTurn();
        yield return new WaitForSeconds(2f);
        Debug.Log("Drew a card");
        Debug.Log("Moving to next phase");
        isPlaceCardsPhase=true;
    }

    public IEnumerator PlaceCardsPhase()
    {
        Debug.Log("Placing card code goes here");
        CardDisplay placeCardDisplay = GetRandomCardInHand();
        Card placeCard = placeCardDisplay.card;
        int index = 0;
        while (field.CheckIfOccupied(index, placeCard.type)){           // Get next available index on the field
            index++;
            if (index >= 3 && placeCard.type == Card.Type.Faculty){
                Debug.Log("Faculty slots are full");
                isActivateEffectPhase = true;
                yield break;
            }
            else if (index >= 7 && placeCard.type == Card.Type.Student){
                Debug.Log("Student slots are full");
                isActivateEffectPhase = true;
                yield break;
            }
        }
        Debug.Log("Placing " + placeCard.name + " at index " + index);
        base.PlaceCard(index, placeCardDisplay);
        yield return new WaitForSeconds(1f);

        Debug.Log("Moving to next phase");
        isActivateEffectPhase = true;
    }

    public IEnumerator ActivateEffectPhase()
    {
        Debug.Log("Activating effect code goes here");
        Player enemy = GameManager.Instance.GetOpposingPlayer();
        CardDisplay self;
        List<CardDisplay> target = new List<CardDisplay>();

        List<BuildingCardDisplay> friendlyBuildings = this.GetField().GetActiveBuildingCards();
        List<BuildingCardDisplay> enemyBuildings = enemy.GetField().GetActiveBuildingCards();

        List<FacultyCardDisplay> friendlyFaculties = this.GetField().GetActiveFacultyCards();
        List<FacultyCardDisplay> enemyFaculties = enemy.GetField().GetActiveFacultyCards(); ;

        List<StudentCardDisplay> friendlyStudents = this.GetField().GetActiveStudentCards();
        List<StudentCardDisplay> enemyStudents = enemy.GetField().GetActiveStudentCards(); 

        DeckLayout friendlyDeck = this.GetDeck();
        DeckLayout enemyDeck = enemy.GetDeck();

        HandLayout friendlyHand = this.GetHand();
        HandLayout enemyHand = enemy.GetHand();

        Player friendly = GameManager.Instance.GetCurrentPlayer();
        Player enemyPlayer = GameManager.Instance.GetOpposingPlayer();

        foreach (StudentCardDisplay student in field.GetActiveStudentCards()){
            self = student;
            CardDisplay temp;
            if (student.GetCardEffectScript().targetTeam == CardEffect.TargetTeam.Friendly){
                temp = field.GetRandomCard(student.GetCardEffectScript().targetType);
                if (temp != null) target.Add(temp);

            }
            else{
                temp = enemy.GetField().GetRandomCard(student.GetCardEffectScript().targetType);
                if (temp != null) target.Add(temp);
            }
            GameData gd = new GameData(friendlyBuildings, enemyBuildings,
                                        friendlyFaculties, enemyFaculties,
                                        friendlyStudents, enemyStudents,
                                        friendlyDeck, enemyDeck,
                                        friendlyHand, enemyHand,
                                        target, self,
                                        friendly, enemyPlayer);
            if (target.Count < student.GetCardEffectScript().numTargets){
                continue;
            }
            student.ActivateEffect(gd);
            target.Clear();
        }
        yield return new WaitForSeconds(1f);
        Debug.Log("Ending turn");
        isEndTurnPhase = true;
        yield return null;
    }

    private CardDisplay GetRandomCardInHand(){
        List<CardDisplay> cardHand = hand.getHand();
        int randIndex = Random.Range(0, cardHand.Count);
        CardDisplay returnCard = cardHand[randIndex];
        return returnCard;
    }
}
