using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBoardSlot : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private Card.Type type;

    private FieldLayout field;

    // Start is called before the first frame update
    void Start()
    {
        field = GetComponentInParent<FieldLayout>();
    }

    public int GetIndex(){
        return index;
    }

    public FieldLayout GetField(){
        return field;
    }

    public Card.Type GetCardType(){
        return type;
    }
}
