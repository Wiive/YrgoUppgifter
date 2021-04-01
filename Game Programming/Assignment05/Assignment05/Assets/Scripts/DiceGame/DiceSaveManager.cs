using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class OurDicePlayers
{
    public DicePlayerInfo[] dicePlayers;
}

[Serializable]
public class DicePlayerInfo
{
    public string userID;
    public string displayName;
    public bool hasGussed;
    public bool guessedHigher;
    public int score;

}

[Serializable]
public class UserInfo
{
    public string name;
    public int sprite;
    public List<string> activeGames;
    public int victories;
}


[Serializable]
public class GameInfo
{
    public string gameID;
    public string displayName;
    public int dice1;
    public int dice2;
    public int round;
    public int numberOfPlayers = 2;
    public List<DicePlayerInfo> dicePlayers;
}