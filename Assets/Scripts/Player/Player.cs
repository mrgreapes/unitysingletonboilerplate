using System;
using UnityEngine;

public class Player
{
    public string playerName;
    public int highScore;
    public int totalScore;
    public float timeSpent;
    public int numberOfGames;
    public int level;
    public int coins;
    public bool isTutorialSeen;

    public Player(string _playerName, int _highScore, int _totalScore, float _timeSpent, int _numberOfGames, int _level, int _coins)
    {
        this.playerName = _playerName;
        this.highScore = _highScore;
        this.totalScore = _totalScore;
        this.timeSpent = _timeSpent;
        this.numberOfGames = _numberOfGames;
        this.level = _level;
        this.coins = _coins;
        isTutorialSeen = (false);
    }
}
