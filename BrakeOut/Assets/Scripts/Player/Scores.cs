using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public Transform transformHighscore;
    public Transform transformScore;
    public TMP_Text Highscoretext;
    public TMP_Text Scoretext;
    public HighScore HighscoreSO;

    
    void Start()
    {
        transformScore = GameObject.Find("Score").transform;
        transformHighscore = GameObject.Find("Highscore").transform;
        Scoretext = transformScore.GetComponent<TMP_Text>();
        Highscoretext = transformHighscore.GetComponent<TMP_Text>();
        //if (PlayerPrefs.HasKey("HighScore"))
        //{
        //   //Highscore = PlayerPrefs.GetInt("Highscore");

        //}
        HighscoreSO.Load();
        Highscoretext.text = $"Highscore: {HighscoreSO.Highscore}";
        HighscoreSO.Score = 0;
    }

    void Update()
    {
        Scoretext.text = $"Score: {HighscoreSO.Score}";
        if (HighscoreSO.Score>HighscoreSO.Highscore)
        {
            HighscoreSO.Highscore = HighscoreSO.Score;
            Highscoretext.text = $"Highscore: {HighscoreSO.Highscore}";
            HighscoreSO.Save();
        }
    }

    public void AddPoints(int points) 
    {
        HighscoreSO.Score += points;
    }

}
