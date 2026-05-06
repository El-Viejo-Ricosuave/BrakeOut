using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownDifficulty : MonoBehaviour
{
    public Options options;
    private TMP_Dropdown Difficulty;

    private void Start() 
    {
        Difficulty = GetComponent<TMP_Dropdown>();
        
        // --- LA LÍNEA MÁGICA ---
        // Sincronizamos la dificultad desde el segundo cero, sin esperar a que el jugador la toque.
        if (options != null)
        {
            options.ChangeDifficulty(Difficulty.value);
        }

        // Y aquí mantenemos tu código original para cuando el jugador sí mueva el menú
        Difficulty.onValueChanged.AddListener(delegate { options.ChangeDifficulty(Difficulty.value); });
    }
}