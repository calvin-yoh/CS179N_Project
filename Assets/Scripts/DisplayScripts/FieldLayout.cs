using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldLayout : MonoBehaviour
{
    [SerializeField] private List<BuildingCardDisplay> buildingCardDisplays = new List<BuildingCardDisplay>();
    [SerializeField] private List<StudentCardDisplay> studentCardDisplays = new List<StudentCardDisplay>();
    [SerializeField] private List<FacultyCardDisplay> FacultyCardDisplays = new List<FacultyCardDisplay>();

    public Card test;

    // Start is called before the first frame update
    void Start()
    {
        //Remove all visible instances of card displays
        foreach (BuildingCardDisplay bcd in buildingCardDisplays)
            bcd.gameObject.SetActive(false);
        foreach (StudentCardDisplay scd in studentCardDisplays)
            scd.gameObject.SetActive(false);
        foreach (StudentCardDisplay scd in studentCardDisplays)
            scd.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            studentCardDisplays[0].card = test;
    }
}
