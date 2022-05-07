using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
