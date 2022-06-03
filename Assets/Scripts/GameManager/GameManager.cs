using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {get {return _instance;}}

    public List<Player> players;
    private int currPlayerIndex = 0;

    //we need to limit the player to playing 1 student and faculty card per turn.
    private void Awake(){
        if (_instance != null && _instance != this){
            Destroy(this.gameObject);
        }
        else{
            _instance = this;
        }
        //maybe here, we can set the 5 building cards.
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Player GetCurrentPlayer(){
        return players[currPlayerIndex];
    }

    public Player GetOpposingPlayer(){
        return players[(currPlayerIndex+1) % 2];
    }

    public Player GetPlayerWithNum(int num)
    {
        foreach (var player in players)
        {
            if (player.number == num)
            {
                return player;
            }
        }
        return null;
    }

    public void SetUpGame(){
        int number = 1;
        foreach (Player p in players){
            p.number = number;
            p.SetUpDeck();
            number++;
            for (int i=0; i < p.numStartingCards; i++){
                p.DrawCard();
            }
        }
        players[0].StartTurn();
    }

    public void SwitchPlayers(){
        currPlayerIndex = (currPlayerIndex + 1) % 2;

        var currPlayer = players[currPlayerIndex];

        if (currPlayer.isAI)
        {
            Debug.Log("Playing AI Turn");
            SimpleAI simpleAI = (SimpleAI)currPlayer;
            CanvasManager.Instance.HideEndTurnButton();
            StartCoroutine(simpleAI.PlayAITurn());
        }
        else
        {
            CanvasManager.Instance.ShowEndTurnButton();
            currPlayer.StartTurn();
        } 
    }

    public GameData GetGameData(CardDisplay thisCard){
        Player player = GetCurrentPlayer();
        Player enemy = GetOpposingPlayer();
        CardDisplay self = thisCard;
        List<CardDisplay> targets = new List<CardDisplay>();

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
        
        return gd;
    }

    public void CheckGameEnded(int playerNumber){
        Player p = players[playerNumber - 1];
        FieldLayout field = p.GetField();
        if (field.GetActiveBuildingCards().Count == 0){
            players.RemoveAt(playerNumber - 1);
        }

        if (players.Count == 1){
            CanvasManager.Instance.ActivateEndScreen(players[0].number);
            
            var UI =  GameObject.FindWithTag("UIcon");
            if(players[0].number == 1){
                UI.GetComponent<UI_controller>().UnlockNextLevel();
            }

            StartCoroutine(ReturnToMenu());
        }
    }

    private IEnumerator ReturnToMenu(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }

}
