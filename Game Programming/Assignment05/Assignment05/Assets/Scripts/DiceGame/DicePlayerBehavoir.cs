using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DicePlayerBehavoir : MonoBehaviour
{
    public int score;
    public string inGameName;
    public TMP_Text scoreText;
    public bool playerGuessHiger;
    public bool hasGuessed;

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int addToScore)
    {
        score += addToScore;
    }

    public void ChangeScoreText(string newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    public void GuessValue(string guess)
    {
        if (guess != "up" || guess != "down")
        {
            Debug.LogError("You inserted not up and down, invalid value to GuessValue");
        }
        else
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
        }    
    }
}
