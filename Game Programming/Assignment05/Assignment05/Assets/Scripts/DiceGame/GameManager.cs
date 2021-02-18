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

    public TMP_Text roundText;
    public int maxRounds = 20;
    public int round = 0;
    private bool player1turn;                                        //Use if only one player can go each turn.

    private int scoreGiven = 500;

    private void Start()
    {               
        player1.ChangeScoreText(player1.GetScore().ToString());     //Later make playerscore load form json /firebase
        player2.ChangeScoreText(player2.GetScore().ToString());

        UpdateValue();
        oldValue = currentValue;
        roundText.text = "Round: " + round.ToString() + "/" + maxRounds.ToString();
    }

    public void NewRound()
    {
        if (round < maxRounds)
        {
            UpdateValue();
            CalculateScores();
            oldValue = currentValue;
            player1.hasGuessed = false;
            player2.hasGuessed = false;
            round++;
            roundText.text = "Round: "+ round.ToString() + "/" + maxRounds.ToString();
        }
        else
        {
            Debug.Log("Game is finnised!");
        }      
    }

    public void UpdateValue()
    {
        currentValue = dice1.GetValue() + dice2.GetValue();
        diceValue.text = (dice1.GetValue() + dice2.GetValue()).ToString();
    }


    private void CalculateScores()
    {
        while(currentValue == oldValue)
        {
            ReRollDices();
        }

        var player1Guess = player1.playerGuessHiger;
        var player2Guess = player2.playerGuessHiger;

        if (player1Guess == CompereDices() && player2Guess == CompereDices())
        {
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


    private void ReRollDices()
    {
        dice1.RollTheDie();
        dice2.RollTheDie();
        UpdateValue();
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