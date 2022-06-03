using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void Start()
    {
        if (CardsManager.instance == null){
            Debug.Log("CardsManager is null");
        }
        else{
            Debug.Log("CardsManager is not null");
        }
    }
}
