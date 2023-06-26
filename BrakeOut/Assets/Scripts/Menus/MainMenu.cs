using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject TitleScreen;

    public void GameStart() 
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void ShowSettings() 
    {
        TitleScreen.SetActive(false);
        Settings.SetActive(true);
    }

    public void ShowTitleScreen() 
    {
        Settings.SetActive(false);    
        TitleScreen.SetActive(true);
    }

}
