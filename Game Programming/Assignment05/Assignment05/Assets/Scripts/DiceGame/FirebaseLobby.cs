
using Firebase.Auth;
using Firebase.Database;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirebaseLobby : MonoBehaviour
{
    public TMP_Text displayName;
    public Transform myGameListPanel;
    public Transform publicGameList;
    public GameObject gameButtonPrefab;

    string userID;
    UserInfo userInfo;
    FirebaseDatabase db;


    void Start()
    {
        userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        db = FirebaseDatabase.DefaultInstance;
        userInfo = ActiveUser.Instance.userInfo;

        displayName.text = userInfo.name;
        UpdateGameList();
    }

    private void UpdateGameList()
    {
        foreach (Transform child in myGameListPanel)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (var gameID in userInfo.activeGames)
        {
            StartCoroutine(FirebaseManager.Instance.LoadData("games/ " + gameID, LoadGameInfo));
        }
    }

    public void LoadGameInfo(string jsondata)
    {
        var gameInfo = JsonUtility.FromJson<GameInfo>(jsondata);

        var newButton = Instantiate(gameButtonPrefab, myGameListPanel).GetComponent<Button>();
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = gameInfo.displayName;
        newButton.onClick.AddListener(() => ActiveGame.Instance.StartGame(gameInfo));
    }

    public void SetName()
    {
        userInfo.name = displayName.text;
        StartCoroutine(FirebaseManager.Instance.SaveData("users/" + userID, JsonUtility.ToJson(userInfo)));
    }

    public void CreateGame()
    {
        if (displayName.text == "" || userInfo.activeGames.Count > 3)
        {
            return;
        }

        var newGameInfo = new GameInfo();
        newGameInfo.displayName = "Game " + newGameInfo.round + "/20";      //Set the game to show how many rounds has gone and of how many

        var dicePlayerInfo = new DicePlayerInfo();
        dicePlayerInfo.displayName = displayName.text;

        newGameInfo.dicePlayers = new List<DicePlayerInfo>();
        newGameInfo.dicePlayers.Add(dicePlayerInfo);

        string key = db.RootReference.Child("games/").Push().Key;
        string path = "games/" + key;

        newGameInfo.gameID = key;
        string jsondata = JsonUtility.ToJson(newGameInfo);

        StartCoroutine(FirebaseManager.Instance.SaveData(path, jsondata));

        GameCreated(key);
    }

    public void GameCreated(string gameKey)
    {
        if (userInfo.activeGames == null)
        {
            userInfo.activeGames = new List<string>();
        }
        userInfo.activeGames.Add(gameKey);

        string jsondata = JsonUtility.ToJson(userInfo);

        StartCoroutine(FirebaseManager.Instance.LoadDataMultiple("games/", ShowGames));
    }

    public void ShowGames(string jsondata)
    {
        var gameInfo = JsonUtility.FromJson<GameInfo>(jsondata);

        if (userInfo.activeGames.Contains(gameInfo.gameID) || gameInfo.dicePlayers.Count > 1)
        {
            return;
        }

        var newButton = Instantiate(gameButtonPrefab, publicGameList).GetComponent<Button>();
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = gameInfo.displayName;
        newButton.onClick.AddListener(() => JoinGame(gameInfo));
    }

    public void JoinGame(GameInfo gameInfo)
    {
        userInfo.activeGames.Add(gameInfo.gameID);

        string jsondata = JsonUtility.ToJson(userInfo);

        StartCoroutine(FirebaseManager.Instance.SaveData("users/" + userID, jsondata));

        var dicePlayerInfo = new DicePlayerInfo();
        dicePlayerInfo.displayName = displayName.text;
        gameInfo.dicePlayers.Add(dicePlayerInfo);

        gameInfo.displayName = gameInfo.dicePlayers[0].displayName + "vs " + dicePlayerInfo.displayName;

        jsondata = JsonUtility.ToJson(gameInfo);

        StartCoroutine(FirebaseManager.Instance.SaveData("games/" + gameInfo.gameID, jsondata));
    }
}
