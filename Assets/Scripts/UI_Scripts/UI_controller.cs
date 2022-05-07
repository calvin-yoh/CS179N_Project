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

    public void GoToLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void GoToLevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void GoToLevelFour()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void GoToLevelFive()
    {
        SceneManager.LoadScene("Level 5");
    }





    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void InitalSave(){

        if( !PlayerPrefs.HasKey("level")) 
            PlayerPrefs.SetInt("level",1);

        PlayerPrefs.Save();

    }

    public void UnlockNextLevel(){
        
        Debug.Log(SceneManager.GetActiveScene().name);

        if(PlayerPrefs.GetInt("level") < SceneManager.GetActiveScene().name[6] - '0' ){
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1 );
            PlayerPrefs.Save();
        }

    }

    public void DeleteSave(){
        PlayerPrefs.DeleteAll();
    }



}
