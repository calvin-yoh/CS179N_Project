using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kalkatos.DottedArrow;

public class CanvasManager : MonoBehaviour
{
    private static CanvasManager _instance;
    public static CanvasManager Instance { get { return _instance; } }

    [SerializeField] private Arrow arrow;
    public CardDescriptionUI cardDescriptionUI;
    public GameObject endTurnButton;

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideEndTurnButton()
    {
        endTurnButton.SetActive(false);   
    }

    public void ShowEndTurnButton()
    {
        endTurnButton.SetActive(true);
    }

    public void EndTurnButtonPressed()
    {
        Player currPlayer = GameManager.Instance.GetCurrentPlayer();
        currPlayer.EndTurn();
        // GameManager.Instance.SwitchPlayers();
    }

    public void ShowCardDetails(CardDisplay cardDisplay)
    {
        cardDescriptionUI.DisplayCard(cardDisplay);
    }

    public void HideCardDetails()
    {
        cardDescriptionUI.ResetUI();
    }

    public void SetUpArrow(Transform pos){
        if(!arrow.isActive)
        {
            arrow.SetupAndActivate(pos);
        }
    }

    public void DeactivateArrow(){
        if(arrow.isActive)
        {
            arrow.Deactivate();
        }
    }
}
