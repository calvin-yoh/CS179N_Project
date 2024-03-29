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

    private const int MAX_STUDENT_CAPACITY = 17;
    private const int MAX_BUILDING_CAPACITY = 5;
    private const int MAX_FACULTY_CAPACITY = 3;
    private const int MAX_TOTAL_CAPACITY = 25;
    private const float MIN_HEIGHT = 1100.0f;

    private int previousChildCount = 0;

    public GameObject studentSymbol;
    public GameObject buildingSymbol;
    public GameObject facultySymbol;

    public void loadCurrentDeck(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
        facultyCount = 0;
        studentCount = 0;
        buildingCount = 0;

        foreach(Card card in CardsManager.instance.getCurrentDeck()){
            var temp = Instantiate(CardsManager.instance.getCardPrefab(card.type));
            temp.GetComponent<CardDisplay>().card = card;
            temp.GetComponent<CardDisplay>().SetUpInformationUI();
            temp.GetComponent<CardDisplay>().DisplayInformationUI();
            temp.transform.SetParent(transform);
            switch(card.type){
                case Card.Type.Building:
                    buildingCount++;
                    break;
                case Card.Type.Student:
                    studentCount++;
                    break;
                case Card.Type.Faculty:
                    facultyCount++;
                    break;
            }
        }


        RectTransform rec = GetComponent<RectTransform>();
        float cardHeight = 375f;

        float rows = Mathf.Ceil(transform.childCount / 2f);

        float new_height = (cardHeight * (rows + 0.5f));
        
        if (new_height > MIN_HEIGHT){
            rec.sizeDelta = new Vector2(rec.sizeDelta.x, new_height);
        }else{
            rec.sizeDelta = new Vector2(rec.sizeDelta.x, MIN_HEIGHT);
        }
    }

    public void OnDrop(PointerEventData eventData){
        addCard(eventData.pointerDrag);
    }

    public void addCard(GameObject card){
        if (transform.childCount >= MAX_TOTAL_CAPACITY){ return; }

        if (card.transform.parent == this.transform){ return; }

        int currentDeck = CardsManager.instance.DeckData.currentDeck;

        switch(card.GetComponent<DragAndDrop>().type){
            case Card.Type.Student:
                if (studentCount >= MAX_STUDENT_CAPACITY) return;
                studentCount++;
                break;  
            case Card.Type.Building:
                if (buildingCount >= MAX_BUILDING_CAPACITY) return;
                if (CardsManager.instance.DeckData.decks[currentDeck].cards.Contains(card.GetComponent<CardDisplay>().GetCardName())) return;
                buildingCount++;
                break;
            case Card.Type.Faculty:
                if (facultyCount >= MAX_FACULTY_CAPACITY) return;
                if (CardsManager.instance.DeckData.decks[currentDeck].cards.Contains(card.GetComponent<CardDisplay>().GetCardName())) return;
                facultyCount++;
                break;
            default:
                return;
        }

        var copy = Instantiate(card, transform.position, transform.rotation);
        copy.GetComponent<RectTransform>().SetParent(this.transform);
        copy.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

        var sound = GetComponent<AudioSource>();
        if(sound != null){
            sound.Play();
        }
        CardsManager.instance.addCardToDeck(card.GetComponent<CardDisplay>().GetCardName());
    }

    void Update(){
        if (transform.childCount != previousChildCount){
            transform.parent.gameObject.GetComponentInChildren<Text>().text =  "Deck: " + transform.childCount.ToString() + " / " + MAX_TOTAL_CAPACITY.ToString();
            
            studentSymbol.GetComponentInChildren<Text>().text = "Student Cards: " + studentCount.ToString() + " / " + MAX_STUDENT_CAPACITY.ToString();
            buildingSymbol.GetComponentInChildren<Text>().text = "Building Cards: " + buildingCount.ToString() + " / " + MAX_BUILDING_CAPACITY.ToString();
            facultySymbol.GetComponentInChildren<Text>().text = "Faculty Cards: " + facultyCount.ToString() + " / " + MAX_FACULTY_CAPACITY.ToString();

            previousChildCount = transform.childCount;

            CardsManager.instance.saveDataToJson();
            RectTransform rec = GetComponent<RectTransform>();

            float cardHeight = 375f;

            float rows = Mathf.Ceil(transform.childCount / 2f);

            float new_height = (cardHeight * (rows + 0.5f));
            
            if (new_height > MIN_HEIGHT){
                rec.sizeDelta = new Vector2(rec.sizeDelta.x, new_height);
            }else{
                rec.sizeDelta = new Vector2(rec.sizeDelta.x, MIN_HEIGHT);
            }
        }
    }
}
