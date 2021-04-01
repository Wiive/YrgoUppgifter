using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DicePlayerBehavoir : MonoBehaviour
{
    public int score;
    public TMP_Text inGameName;
    public TMP_Text scoreText;
    public bool playerGuessHiger;
    public bool hasGuessed;

    public UnityEvent getNewScore;
    public UnityEvent hasGuessedEvent;

    private void Start()
    {
        if(getNewScore == null)
        {
            getNewScore = new UnityEvent();
        }

        if (hasGuessedEvent == null)
        {
            hasGuessedEvent = new UnityEvent();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int addToScore)
    {
        getNewScore.Invoke();
        score += addToScore;
    }

    public void ChangeScoreText(string newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    public void GuessValue(string guess)
    {
        if (guess == "up" || guess == "down")
        {
            if (guess == "up")
            {
                playerGuessHiger = true;
            }
            else
            {
                playerGuessHiger = false;
            }
            hasGuessed = true;
            hasGuessedEvent.Invoke();
        }
        else
        {
            Debug.LogError("You inserted not up and down, invalid value to GuessValue");
        }    
    }
}
