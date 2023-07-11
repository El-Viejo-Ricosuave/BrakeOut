using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlocks : MonoBehaviour
{
    public GameObject SomeBlocks;
    public float Xtime;

    void Start() 
    {
        InvokeRepeating("Spawning",0f, Xtime);
    }

    void Spawning () 
    {
        SomeBlocks.SetActive(!SomeBlocks.activeInHierarchy);
    }

    void Update()
    {
        
    }
}
