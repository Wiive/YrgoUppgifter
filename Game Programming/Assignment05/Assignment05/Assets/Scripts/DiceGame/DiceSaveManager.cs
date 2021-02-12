using System;
using System.IO;
using System.Net;
using System.Text;
using TMPro;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;

[Serializable]
public class OurDicePlayers
{
    public DicePlayerInfo[] dicePlayers;
}

[Serializable]
public class DicePlayerInfo
{
    public int Score;
    public string Name;
}

public class DiceSaveManager : MonoBehaviour
{
    public GameObject dicePlayer1;
    public GameObject dicePlayer2;

    public void SaveData()
    {
        Debug.Log("Saved");

        //Get player info
        var players = FindObjectsOfType<DicePlayerBehavoir>();

        //Create holder object
        var ourDicePlayers = new OurDicePlayers();

        ourDicePlayers.dicePlayers = new DicePlayerInfo[players.Length];

        //Put info in playerinfo class
        for (int i = 0; i < players.Length; i++)
        {
            ourDicePlayers.dicePlayers[i] = new DicePlayerInfo();
            ourDicePlayers.dicePlayers[i].Score = players[i].score;
            ourDicePlayers.dicePlayers[i].Name = players[i].inGameName;
        }

        //turn class into json
        string jsonsString = JsonUtility.ToJson(ourDicePlayers);

        //Save Jsonsfile
        SaveToFireBase(jsonsString);

    }

    private void SaveToFireBase(string data)
    {
        var db = FirebaseDatabase.DefaultInstance;
        var dataTask = db.RootReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).SetRawJsonValueAsync(data);
    }

}
