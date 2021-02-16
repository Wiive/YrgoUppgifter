using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{  
    public DiceSides dice1;
    public DiceSides dice2;
    public TMP_Text diceValue;

    public DicePlayerBehavoir player1;
    public DicePlayerBehavoir player2;

    private int currentValue;
    private int oldValue;

    private int scoreGiven = 500;
    public int round = 0;
    bool player1turn;

    private void Start()
    {

        //Later make playerscore load form json /firebase
        player1.ChangeScoreText(player1.GetScore().ToString());
        player2.ChangeScoreText(player2.GetScore().ToString());

        UpdateValue();
    }

    public void NewTurn()
    {
        UpdateValue();
        CalculateScores();
        oldValue = currentValue;
    }

    public void UpdateValue()
    {
        currentValue = dice1.GetValue() + dice2.GetValue();
        diceValue.text = (dice1.GetValue() + dice2.GetValue()).ToString();
    }


    private void CalculateScores()
    {
        var player1Guess = player1.playerGuessHiger;
        var player2Guess = player2.playerGuessHiger;

        if (player1Guess == CompereDices() && player2Guess == CompereDices())
        {
            Debug.Log("Both Players Guess right!");
            player1.UpdateScore(scoreGiven / 2);
            player2.UpdateScore(scoreGiven / 2);
        }
        else if (player1Guess == CompereDices())
        {
            player1.UpdateScore(scoreGiven);
        }
        else if (player2Guess == CompereDices())
        {
            player2.UpdateScore(scoreGiven);
        }
        player1.ChangeScoreText(player1.GetScore().ToString());
        player2.ChangeScoreText(player2.GetScore().ToString());
    }

    public bool CompereDices()
    {
        if (currentValue > oldValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
