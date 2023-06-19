using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Highscore", menuName = "Tools/Highscore", order = 0)]
public class HighScore : PersistentScore
{
    public int Score = 0;
    public int Highscore = 0;
}
