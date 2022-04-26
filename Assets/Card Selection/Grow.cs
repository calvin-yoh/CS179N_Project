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
        rec.sizeDelta = new Vector2(1300, (cardHeight * rows) + 100);
    }
}
