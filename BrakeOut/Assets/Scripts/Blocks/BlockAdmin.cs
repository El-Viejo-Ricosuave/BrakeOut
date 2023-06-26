using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAdmin : MonoBehaviour
{
    public GameObject LevelEndMenu;

    void Update() 
    {
        if (transform.childCount == 0) 
        {
            LevelEndMenu.SetActive(true);
        }   
    }
}
