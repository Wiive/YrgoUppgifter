using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject goal1;
    public GameObject goal2;
    public Text goal1ScoreText;
    public Text goal2ScoreText;
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    private void Start()
    {

    }

    private void Update()
    {
        
        goal1ScoreText.text = "Player One Score: " + scorePlayer1;
        goal2ScoreText.text = "Player Two Score: " + scorePlayer2;
    }


}
