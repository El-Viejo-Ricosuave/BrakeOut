using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Options", menuName = "Tools/Options", order = 1)]
public class Options : ScriptableObject
{
    public float AmmoSpeed = 30f;
    // Solo dejamos una variable para la velocidad del jugador
    public float PlayerSpeed = 66.6f; 
    public difficulty Difficultylevel = difficulty.easy;

    public enum difficulty { easy, medium, hard }

    // Esta función la usará tu nuevo slider del Player
    public void ChangePlayerSpeed(float nuevaVelocidad)
    {
        PlayerSpeed = nuevaVelocidad;
    }

    // Esta función la usará tu slider original de la bola
    public void ChangeSpeed(float newSpeed) 
    {
        AmmoSpeed = newSpeed;
        // Ya quitamos la línea que amarraba las velocidades. 
        // ¡Ahora tus dos sliders son 100% independientes!
    }

    public void ChangeDifficulty(int newDifficulty) 
    {
        Difficultylevel = (difficulty)newDifficulty;
    }
}