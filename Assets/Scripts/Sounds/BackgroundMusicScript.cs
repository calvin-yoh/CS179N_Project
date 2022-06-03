using System;
using System.Globalization;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public static BackgroundMusicScript BackgroundInstance;

    private void Awake() {
        if(BackgroundInstance != null && BackgroundInstance != this) {
            Destroy(this.gameObject);
            return;
        }

        BackgroundInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
