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

    public Card.Type GetCardType(){
        return type;
    }

    public void PlaceCard(Card newCard){
        field.ActivateCard(index, newCard, type);
    }
}
