using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/StudentCard")]
public class StudentCard : Card
{
    //public int health;

    public override void ApplyEffect()
    {
        Debug.Log("This card's duration is : " + duration);
    }
}
