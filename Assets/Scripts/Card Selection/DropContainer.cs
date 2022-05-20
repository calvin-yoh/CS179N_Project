using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


public class DropContainer : MonoBehaviour, IDropHandler
{
    public  int facultyCount = 0;
    public  int studentCount = 0;
    public  int buildingCount = 0;

    private const int MAX_STUDENT_CAPACITY = 12;
    private const int MAX_BUILDING_CAPACITY = 5;
    private const int MAX_FACULTY_CAPACITY = 3;
    private const int MAX_TOTAL_CAPACITY = 20;

    public void OnDrop(PointerEventData eventData){
        string[] accepted = {"UIStudentCard(Clone)", "UIBuildingCard(Clone)", "UIFacutlyCard(Clone)"};
        if (transform.childCount >= MAX_TOTAL_CAPACITY){ return; }

        switch(eventData.pointerDrag.name){
            case "UIStudentCard(Clone)":
                if (studentCount >= MAX_STUDENT_CAPACITY) return;
                studentCount++;
                break;  
            case "UIBuildingCard(Clone)":
                if (buildingCount >= MAX_BUILDING_CAPACITY) return;
                buildingCount++;
                break;
            case "UIFacultyCard(Clone)":
                if (facultyCount >= MAX_FACULTY_CAPACITY) return;
                facultyCount++;
                break;
            default:
                return;
        }

        var copy = Instantiate(eventData.pointerDrag, transform.position, transform.rotation);
        copy.GetComponent<RectTransform>().SetParent(this.transform);
        copy.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

        RectTransform rec = GetComponent<RectTransform>();

        float cardHeight = 375f;

        float rows = Mathf.Ceil(transform.childCount / 2f);



        float new_height = (cardHeight * (rows + 0.5f));
        
        if (new_height > rec.sizeDelta.y){
            rec.sizeDelta = new Vector2(rec.sizeDelta.x, new_height);
        }


        transform.parent.gameObject.GetComponentInChildren<Text>().text =  "Deck: " + transform.childCount.ToString() + " / 20";
    }
}
