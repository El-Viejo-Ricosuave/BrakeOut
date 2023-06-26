using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void Nextlevel() 
    {
        var Nextlevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > Nextlevel)
        {
            SceneManager.LoadScene(Nextlevel);
        }
        else 
        {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
