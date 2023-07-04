using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Settings;



    public void ShowPauseMenu() 
    {
        Pause.SetActive(true);
        if (Pause.activeInHierarchy) Settings.SetActive(false);
        Time.timeScale = 0f;
    }

    public void HidePauseMenu() 
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToTitleScreen() 
    {
        SceneManager.LoadScene(0);
    }

    public void ShowSettings() 
    {
        Pause.SetActive(false);
        Settings.SetActive(true);
    }


}
