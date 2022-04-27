using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float cardHeight;
    public int rows;
    private RectTransform rec;
    void Start()
    {
        rec = GetComponent<RectTransform>();

        float new_height = (cardHeight * rows);
        
        rec.sizeDelta = new Vector2(1300, new_height);

        rec.position = new Vector3(0, -(new_height / 2), 0);
    }
}
