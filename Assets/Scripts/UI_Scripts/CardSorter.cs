using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardSorter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject grid;
    private List <Transform> cards;
    void Start()
    {
        foreach (Transform card in transform)
        {
            cards.Add(card);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void sortByName(){
        TMP_Text currText;
        for (int i = 0; i < cards.lenth; i++)
        {

        }
        foreach (Transform card in cards)
        {
            currText = card.transform.getChild(2).GetComponent<TMP_Text>();
            if(currText < minText){

            }
        }
    }
    */
}
