using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public GameObject scoreManagerObject;
    ScoreManager scoreManager;
    public int playerNumber;

    private void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Walnut"))
        {
            Debug.Log(other.gameObject.name + " have entered");
            if (playerNumber == 1)
            {
                scoreManager.scorePlayer1++;
            }
            if (playerNumber == 2)
            {
                scoreManager.scorePlayer2++;
            }

        }
    }

}
