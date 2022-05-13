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
        TMP_Text compareText;
        for (int i = 0; i < cards.lenth; i++)
        {

        }

        for (int i = 0; i < cards.Count; i++)
        {
            currText = cards[i].transform.getChild(2).GetComponent<TMP_Text>();

            for (int j = 0; j < cards.Count; j ++){
                compareText = cards[j].transform.getChild(2).GetComponent<TMP_Text>();
                if(currText.text<compareText.text){
                    //swap indices.
                    Transform temp = cards[i];
                    cards[j].transform.setSiblingIndex(i);
                    cards[i].transform.setSiblingIndex(j);
                }
            }

        }
    }
    */
    
    void sortByType()
    {

    }
}
