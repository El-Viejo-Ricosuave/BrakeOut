using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownDifficulty : MonoBehaviour
{
    public Options options;
    private Dropdown Difficulty;

    private void Start() 
    {
        Difficulty = GetComponent<Dropdown>();
        Difficulty.onValueChanged.AddListener(delegate { options.ChangeDifficulty(Difficulty.value); });
    }

}
