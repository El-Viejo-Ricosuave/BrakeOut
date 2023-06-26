using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Options", menuName = "Tools/Options", order = 1)]

public class Options : ScriptableObject
{
    public float Ammospeed = 30;
    public difficulty Difficultylevel = difficulty.easy;
    public int PlayerSpeed = 10;

    public enum difficulty { easy, medium, hard}
   

    public void ChangeSpeed(float newSpeed) 
    {
        Ammospeed = newSpeed;
    }

    public void ChangeDifficulty(int newDifficulty) 
    {
        Difficultylevel = (difficulty)newDifficulty;
    }

    public void Playerspeed(int newSpeed) 
    {

        PlayerSpeed = newSpeed; 
    }

}
