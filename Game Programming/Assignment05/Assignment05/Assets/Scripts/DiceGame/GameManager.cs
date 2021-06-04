using Firebase.Database;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Dice")]
    public DiceSides dice1;
    public DiceSides dice2;
    public TMP_Text diceValue;

    private int currentValue;
    private int oldValue;

    [Header("Players")]
    public DicePlayerBehavoir player1;
    public DicePlayerBehavoir player2;
    public CanvasGroup player1up;
    public CanvasGroup player1down;
    public CanvasGroup player2up;
    public CanvasGroup player2down;

    private DicePlayerBehavoir currentPlayer;
    private DicePlayerBehavoir otherPlayer;

    [Header("Game Status")]
    public TMP_Text roundText;
    public int round = 0;
    public int maxRounds = 15;
    public GameObject exitButton;

    private int scoreGiven = 500; 
    private bool gameEnded;
    public enum PlayerStatus { guessing, waiting, win, lose, draw }
    public PlayerStatus currentStatus;
    public TMP_Text gameStatusText;
    public UnityEvent newRound;

    private GameInfo gameInfo;

    private void Start()
    {
        if (newRound == null)
        {
            newRound = new UnityEvent();
        }
        exitButton.SetActive(false);

        //Start with values from that activeGameInfo
        gameInfo = ActiveGame.Instance.activeGameInfo;
        round = gameInfo.round;

        dice1.RollTheDie(gameInfo.dice1);
        dice2.RollTheDie(gameInfo.dice2);
       
        //Load Dice Players Info
        player1.inGameName.text = gameInfo.dicePlayers[0].displayName;
        player2.inGameName.text = gameInfo.dicePlayers[1].displayName;
        player1.score = gameInfo.dicePlayers[0].score;
        player2.score = gameInfo.dicePlayers[1].score;
        player1.ChangeScoreText(player1.GetScore().ToString());
        player2.ChangeScoreText(player2.GetScore().ToString());
        player1.GetComponent<SetSprite>().UpdateSprite(gameInfo.dicePlayers[0].spriteIndex);
        player2.GetComponent<SetSprite>().UpdateSprite(gameInfo.dicePlayers[1].spriteIndex);

        UpdateValue();
        oldValue = currentValue;
        roundText.text = "Round: " + round.ToString() + "/" + maxRounds.ToString();

        UpdateDicePlayerToActivePlayer();

        UpdateStatusTextGuessed();
    }


    public void Update()
    {
        if (round < maxRounds)
        {
            if (player1.hasGuessed && player2.hasGuessed)
            {
                Debug.Log("If both have guessed. Create new Round");
                dice1.RollTheDie(gameInfo.dice1);
                dice2.RollTheDie(gameInfo.dice2);
                NewRound();
            }      
        }

        else if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("Game is finnised!");
            UpdateWinner();
        }

    }

    public void UpdateDicePlayerToActivePlayer()
    {
        string playerID = ActiveUser.Instance.userID;
        if (playerID == gameInfo.dicePlayers[0].userID)
        {
            player2up.alpha = 0;
            player2down.alpha = 0;
            player2up.interactable = false;
            player2down.interactable = false;
            currentPlayer = player1;
            otherPlayer = player2;
        }
        else
        {
            player1up.alpha = 0;
            player1down.alpha = 0;
            player1up.interactable = false;
            player1down.interactable = false;
            currentPlayer = player2;
            otherPlayer = player1;
        }
    }


    public void UpdateStatusTextGuessed()
    {
        if (!currentPlayer.hasGuessed && !otherPlayer.hasGuessed)
        {
            currentStatus = PlayerStatus.guessing;
        }
        else if (currentPlayer.hasGuessed)
        {
            currentStatus = PlayerStatus.waiting;
        }
        ChangeStatusText();
    }

    private void ChangeStatusText()
    {
        switch (currentStatus)
        {
            case PlayerStatus.waiting:
                gameStatusText.text = "Waiting for other player";
                break;

            case PlayerStatus.guessing:
                gameStatusText.text = "Guess higher or lower";
                break;

            case PlayerStatus.win:
                gameStatusText.text = "GZ! YOU WON!";
                break;

            case PlayerStatus.lose:
                gameStatusText.text = "aww... you didn't make it this time.";
                break;

            case PlayerStatus.draw:
                gameStatusText.text = "You made a draw!";
                break;
        }
    }


    public void UpdateGuessOnline()
    {
        string player = "/dicePlayers/";
        int i;
        if (currentPlayer == player1)
        {
            gameInfo.dicePlayers[0].guessedHigher = currentPlayer.playerGuessHiger;
            gameInfo.dicePlayers[0].hasGussed = currentPlayer.hasGuessed;
            player1up.interactable = false;
            player1down.interactable = false;

            player += 0;
            i = 0;
        }
        else
        {
            gameInfo.dicePlayers[1].guessedHigher = currentPlayer.playerGuessHiger;
            gameInfo.dicePlayers[1].hasGussed = currentPlayer.hasGuessed;
            player2up.interactable = false;
            player2down.interactable = false;

            player += 1;
            i = 1;
        }

        RefreshFromOnline();
        string path = "games/" + gameInfo.gameID + player;
        string jsondata = JsonUtility.ToJson(gameInfo.dicePlayers[i]);
        StartCoroutine(FirebaseManager.Instance.SaveData(path, jsondata));
        ActiveGame.Instance.activeGameInfo = gameInfo;
    }

    public void RefreshFromOnline()
    {
        string path = "games/" + gameInfo.gameID;
        StartCoroutine(FirebaseManager.Instance.LoadData(path, LoadUpdatedGameInfo));
    }

    public void LoadUpdatedGameInfo(string jsondata)
    {
        var gameInfo = JsonUtility.FromJson<GameInfo>(jsondata);
        ActiveGame.Instance.activeGameInfo = gameInfo;
        this.gameInfo = gameInfo;
        Debug.Log("Loading gusses from online");
        if (currentPlayer == player1)
        {
            player2.playerGuessHiger = gameInfo.dicePlayers[1].guessedHigher;
            player2.hasGuessed = gameInfo.dicePlayers[1].hasGussed;
        }
        else
        {
            player1.playerGuessHiger = gameInfo.dicePlayers[0].guessedHigher;
            player1.hasGuessed = gameInfo.dicePlayers[0].hasGussed;
        }
    }



    public void NewRound()
    {        
        UpdateValue();
        CalculateScores();
        oldValue = currentValue;
        Debug.Log("Start a new round, set player hasGussed to false");
        player1.hasGuessed = false;
        player2.hasGuessed = false;
        round++;
        roundText.text = "Round: " + round.ToString() + "/" + maxRounds.ToString();
        newRound.Invoke();
        UpdateRoundOnline();

        if (currentPlayer == player1)
        {
            player1up.interactable = true;
            player1down.interactable = true;
        }
        else
        {
            player2up.interactable = true;
            player2down.interactable = true;
        }
        
    }

    public void UpdateRoundOnline()
    {
        gameInfo.round = round;
        gameInfo.dicePlayers[0].score = player1.score;
        gameInfo.dicePlayers[1].score = player2.score;
        gameInfo.dicePlayers[0].hasGussed = player1.hasGuessed;
        gameInfo.dicePlayers[1].hasGussed = player2.hasGuessed;
        //Dice seeds
        int seed1 = Random.Range(0, 100);
        int seed2 = Random.Range(0, 100);
        Debug.Log("UpdateRoundOnline: Updating Dices");
        gameInfo.dice1 = seed1;
        gameInfo.dice2 = seed2;

        string path = "games/" + gameInfo.gameID;
        string jsondata = JsonUtility.ToJson(gameInfo);
        StartCoroutine(FirebaseManager.Instance.SaveData(path, jsondata));
        ActiveGame.Instance.activeGameInfo = gameInfo;
    }


    public void UpdateValue()
    {
        currentValue = dice1.GetValue() + dice2.GetValue();
        diceValue.text = currentValue.ToString();
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
        Debug.Log("Rerolling");
        int seed1 = Random.Range(0, 100);
        int seed2 = Random.Range(0, 100);
        gameInfo.dice1 = seed1;
        gameInfo.dice2 = seed2;
        dice1.RollTheDie(gameInfo.dice1);
        dice2.RollTheDie(gameInfo.dice2);
        UpdateValue();

        string path = "games/" + gameInfo.gameID;
        string jsondata = JsonUtility.ToJson(gameInfo);
        StartCoroutine(FirebaseManager.Instance.SaveData(path, jsondata));
        ActiveGame.Instance.activeGameInfo = gameInfo;
        Debug.Log("Reolling: Updating Dices and game Game Info");
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

    public void UpdateWinner()
    {
        var activeUser = ActiveUser.Instance.userInfo;

        exitButton.SetActive(true);

        if (currentPlayer.score > otherPlayer.score)
        {
            Debug.Log("You WON!");
            activeUser.victories++;
            currentStatus = PlayerStatus.win;
            ChangeStatusText();                   
        }
        else if (currentPlayer.score < otherPlayer.score)
        {
            Debug.Log("You lost");
            currentStatus = PlayerStatus.lose;
            ChangeStatusText();
        }
        else
        {
            Debug.Log("It's a draw");
            currentStatus = PlayerStatus.draw;
            ChangeStatusText();
        }

        //Remove game online?

        //Update a box that anounce the ending in the screen.


        //Exit button is back to lobby, its should destroy the game
    }

    public void ExitFinnishedGame()
    {
        var activeUser = ActiveUser.Instance.userInfo;

        //Remove game for user
        for (int i = 0; i < activeUser.activeGames.Count; i++)
        {
            if (activeUser.activeGames[i].Equals(gameInfo.gameID))
            {
                activeUser.activeGames.RemoveAt(i);
            }
        }

        //Save online
        string path = "users/" + activeUser;
        string jsondata = JsonUtility.ToJson(activeUser);
        Debug.Log("Saving winner to database");
        StartCoroutine(FirebaseManager.Instance.SaveData(path, jsondata));
    }
}