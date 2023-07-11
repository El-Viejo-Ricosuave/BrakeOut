using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownDifficulty : MonoBehaviour
{
    public Options options;
    private Dropdown difficulty;
    private TMP_Dropdown Difficulty;

    private void Start() 
    {
        Difficulty = GetComponent<TMP_Dropdown>();
        Difficulty.onValueChanged.AddListener(delegate { options.ChangeDifficulty(Difficulty.value); });
    }

}
