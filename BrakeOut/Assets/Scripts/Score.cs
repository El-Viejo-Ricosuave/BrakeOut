using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform transformHighScore;
    public Transform transformCurrentScore;
    public TMP_Text Highscoretext;
    public TMP_Text Scoretext;
    public int Points = 0;
    public int HighScore = 10000;

    void Start()
    {
        transformCurrentScore = GameObject.Find("Score").transform;
        transformHighScore = GameObject.Find("HighScore").transform;
        Scoretext = transformCurrentScore.GetComponent<TMP_Text>();
        Highscoretext = transformHighScore.GetComponent<TMP_Text>();
    }

    void FixedUpdate()
    {
        Points += 10;
    }

    void Update()
    {
        Scoretext.text = $"Score: {Points}";
        if (Points > HighScore) 
        {
            HighScore = Points;
            Highscoretext.text = $"Highscore: {HighScore}";
        }
    }
}
