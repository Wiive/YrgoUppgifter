using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{  
    public DiceSides dice1;
    public DiceSides dice2;
    public TMP_Text diceValue;

    public TMP_Text player1Score;
    public TMP_Text player2Score;

    private void Start()
    {
        diceValue.text = "";
    }

    public void UpdateValue()
    {
        diceValue.text = (dice1.GetValue() + dice2.GetValue()).ToString();
    }

    private void CalculateScores()
    {
        //Do some math based on players guess.
    }

    private void ReadPlayerGusses()
    {
        //Make bools or enums for what the player have choosen and make sure it is some kind of turn calculating?
    }
}
