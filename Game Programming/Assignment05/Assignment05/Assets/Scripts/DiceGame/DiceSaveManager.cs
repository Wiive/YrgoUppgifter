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
    public string status;
    public int score;
    public string displayName;
}

[Serializable]
public class UserInfo
{
    public string name;
    public string sprite;
    public List<string> activeGames;
    public int victories;
}


[Serializable]
public class GameInfo
{
    public string displayName;
    public string gameID;
    public int round;
    public int numberOfPlayers = 2;
    public List<DicePlayerInfo> dicePlayers;
}