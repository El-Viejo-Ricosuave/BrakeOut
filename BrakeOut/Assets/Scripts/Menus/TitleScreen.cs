using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    public TMP_Text Title;

    void FixedUpdate() 
    {

        GetComponent<TMP_Text>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f),1);
       
    }

}
