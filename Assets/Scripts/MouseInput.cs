using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private static MouseInput _instance;
    public static MouseInput Instance {get {return _instance;}}

    public GameObject currObject;

    private void Awake(){
        if (_instance != null && _instance != this){
            Destroy(this.gameObject);
        }
        else{
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currObject = checkObjectClicked();
    }

    GameObject checkObjectClicked(){
        if (Input.GetMouseButtonDown(0)){
            // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            // RaycastHit hit = Physics.Raycast(mousePos, Vector2.zero);
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(r, out hit);
            if (hit.collider != null){
                if (hit.collider.tag == "Card"){
                    Card c = hit.collider.gameObject.GetComponent<CardDisplay>().card;
                    c.ApplyEffect();
                }
                // Debug.Log("Clicked on " + hit.collider.gameObject.name);
                return hit.collider.gameObject;
            }
            return null;
        }
        return null;
    }
}
