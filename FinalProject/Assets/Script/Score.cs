using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public int score = 0;
    public int highscore = 0;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Scores: " + score.ToString();
        highScoreText.text = "HIGHSCORE: " + highscore.ToString(); ;
    }

    public void addScore()
    {
        score += 10;
        scoreText.text = "Scores: " + score.ToString();
        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
