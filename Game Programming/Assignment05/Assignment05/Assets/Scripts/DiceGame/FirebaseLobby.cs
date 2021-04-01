
using Firebase.Auth;
using Firebase.Database;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirebaseLobby : MonoBehaviour
{
    [Header("User Setup")]
    public TMP_Text displayName;
    public TMP_Text victories;
    public Image avatar;
    public List<Sprite> avatarSprite;

    [Header("Game Setup")]
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
        victories.text = "Victories: " + userInfo.victories.ToString();
        avatar.sprite = avatarSprite[userInfo.sprite];

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
            StartCoroutine(FirebaseManager.Instance.LoadData("games/" + gameID, LoadGameInfo));
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
        Debug.Log("tryin to create game");
        if (displayName.text == "" || userInfo.activeGames.Count > 2)
            return;
        

        Debug.Log("Trying to create Game Info for new game");
        var newGameInfo = new GameInfo();
        newGameInfo.displayName = "Game " + newGameInfo.round + "/20";      //Set the game to show how many rounds has gone and of how many

        var dicePlayerInfo = new DicePlayerInfo();
        dicePlayerInfo.userID = ActiveUser.Instance.userID;
        dicePlayerInfo.displayName = displayName.text;

        newGameInfo.dicePlayers = new List<DicePlayerInfo>();
        newGameInfo.dicePlayers.Add(dicePlayerInfo);

        //Create seed for first dice rolls
        int seed1 = Random.Range(0, 100);
        int seed2 = Random.Range(0, 100);
        newGameInfo.dice1 = seed1;
        newGameInfo.dice2 = seed2;

        string key = db.RootReference.Child("games/").Push().Key;
        string path = "games/" + key;

        newGameInfo.gameID = key;
        string jsondata = JsonUtility.ToJson(newGameInfo);

        StartCoroutine(FirebaseManager.Instance.SaveData(path, jsondata));

        GameCreated(key);          
    }

    public void GameCreated(string gameKey)
    {
        Debug.Log("Trying to att game to list");
        if (userInfo.activeGames == null)
        {
            userInfo.activeGames = new List<string>();
        }
        userInfo.activeGames.Add(gameKey);

        string jsondata = JsonUtility.ToJson(userInfo);

        StartCoroutine(FirebaseManager.Instance.SaveData("users/" + userID, jsondata, UpdateGameList));
    }

    public void ListGames()
    {
        Debug.Log("Listing Games");

        //Remove the old list
        foreach (Transform child in publicGameList)
            GameObject.Destroy(child.gameObject);

        //Load games and create a new list
        StartCoroutine(FirebaseManager.Instance.LoadDataMultiple("games/", ShowGames));
    }

    public void ShowGames(string jsondata)
    {
        Debug.Log("Trying to Show games");
        var gameInfo = JsonUtility.FromJson<GameInfo>(jsondata);

        if (userInfo.activeGames.Contains(gameInfo.gameID) || gameInfo.dicePlayers.Count > 1)
        {
            Debug.Log("Game is full or player already in that game");
            return;
        }

        Debug.Log("Creating button");
        var newButton = Instantiate(gameButtonPrefab, publicGameList).GetComponent<Button>();
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = gameInfo.displayName;
        newButton.onClick.AddListener(() => JoinGame(gameInfo));   
       
    }

    public void JoinGame(GameInfo gameInfo)
    {
        Debug.Log("Trying to join game");
        userInfo.activeGames.Add(gameInfo.gameID);

        string jsondata = JsonUtility.ToJson(userInfo);

        StartCoroutine(FirebaseManager.Instance.SaveData("users/" + userID, jsondata));

        var dicePlayerInfo = new DicePlayerInfo();
        dicePlayerInfo.displayName = displayName.text;
        dicePlayerInfo.userID = ActiveUser.Instance.userID;
        gameInfo.dicePlayers.Add(dicePlayerInfo);

        gameInfo.displayName = gameInfo.dicePlayers[0].displayName + " vs " + dicePlayerInfo.displayName;

        jsondata = JsonUtility.ToJson(gameInfo);

        StartCoroutine(FirebaseManager.Instance.SaveData("games/" + gameInfo.gameID, jsondata));
    }

    public void LogOut()
    {
        var auth = FirebaseAuth.DefaultInstance;
        auth.SignOut();
        ActiveUser.Instance.userID = null;
        ActiveUser.Instance.userInfo = null;
        ActiveGame.Instance.activeGameInfo = null;
    }
}
