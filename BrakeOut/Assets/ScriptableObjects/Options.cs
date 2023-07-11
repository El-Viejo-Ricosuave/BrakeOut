using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Options", menuName = "Tools/Options", order = 1)]

public class Options : ScriptableObject
{
    public float AmmoSpeed = 30;
    public difficulty Difficultylevel = difficulty.easy;


    public enum difficulty { easy, medium, hard}
   

    public void ChangeSpeed(float newSpeed) 
    {
        AmmoSpeed = newSpeed;
    }

    public void ChangeDifficulty(int newDifficulty) 
    {
        Difficultylevel = (difficulty)newDifficulty;
    }


}
