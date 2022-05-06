using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class LevelLoader : MonoBehaviour
{
    public Button[] allChildren;
    public List<Button>  levels;
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {   

        Canvas = GameObject.Find("LevelCanvas");

        int unlockLvls = PlayerPrefs.GetInt("level");

        allChildren = Canvas.GetComponentsInChildren<Button>();

        foreach(Button x in allChildren){
            if(x.tag == "LevelButton"){
                levels.Add(x);
            }

        }

        for(int i = 0; i < unlockLvls; i++){

            levels.ElementAt(i).interactable = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
