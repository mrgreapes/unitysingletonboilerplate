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
    public PlayerSettings playerGameSettings;
    public Player(string _playerName, int _highScore, int _totalScore, float _timeSpent, int _numberOfGames, int _level, int _coins, PlayerSettings _playerGameSettings)
    {
        this.playerName = _playerName;
        this.highScore = _highScore;
        this.totalScore = _totalScore;
        this.timeSpent = _timeSpent;
        this.numberOfGames = _numberOfGames;
        this.level = _level;
        this.coins = _coins;
        isTutorialSeen = (false);
        this.playerGameSettings = _playerGameSettings;

    }
}
public class PlayerSettings
{
    public bool music;
    public bool sound;
    public float musicVolume;
    public float soundVolume;
    public bool vibration;
    public bool notifications;

    public PlayerSettings(bool _music, bool _sound, float _musicVolume, float _soundVolume, bool _vibration, bool _notifications)
    {
        this.music = _music;
        this.sound = _sound;
        this.musicVolume = _musicVolume;
        this.soundVolume = _soundVolume;
        this.vibration = _vibration;
        this.notifications = _notifications;
    }
}
