using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public TMP_Text timeText;

    public GameObject endMenu;
    public NetworkSend _command;
    public startGame _startGame;

    public TMP_Text EndScore;
    public TMP_Text EndHighScore;
    public Score _endScore;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }

            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;

            _startGame.isRelease = false;
            _startGame.isSelected = false;
            _command.Send("0");

            endMenu.SetActive(true);
            _endScore.scoreText.text = EndScore.text;
            EndScore.text = "Score: " + _endScore.score.ToString();

            _endScore.highScoreText.text = EndHighScore.text;
            EndHighScore.text = "HIGHSCORE: " + _endScore.highscore.ToString();
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timeText.text = string.Format("Timer: " + "{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}