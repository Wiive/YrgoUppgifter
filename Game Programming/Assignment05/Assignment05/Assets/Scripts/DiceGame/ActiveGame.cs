using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    private static ActiveGame instance;
    public static ActiveGame Instance { get { return instance; } }

    public GameInfo activeGameInfo;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void StartGame(GameInfo gameInfo)
    {
        activeGameInfo = gameInfo;

        Debug.Log("Trying to Start Game: " + gameInfo);
        GetComponent<LevelManager>().LoadScene(2);
    }
}
