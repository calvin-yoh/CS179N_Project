using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private static CanvasManager _instance;
    public static CanvasManager Instance { get { return _instance; } }

    public CardDescriptionUI cardDescriptionUI;

    // Start is called before the first frame update
    void Start()
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

    public void EndTurnButtonPressed()
    {
        GameManager.Instance.SwitchPlayers();
    }

    public void ShowCardDetails(CardDisplay cardDisplay)
    {
        cardDescriptionUI.DisplayCard(cardDisplay);
    }

    public void HideCardDetails()
    {
        cardDescriptionUI.ResetUI();
    }



}
