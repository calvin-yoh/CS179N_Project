using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_controller : MonoBehaviour
{
    public void GoToStoryScene()
    {
        SceneManager.LoadScene("StoryModeScene");
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }



}
