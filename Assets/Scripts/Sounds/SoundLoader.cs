using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume")){
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else 
        {
            Load();
        }
    }

    private void Load()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

}
