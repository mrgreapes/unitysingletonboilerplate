using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService
{
    //public PlayerStats _player;

    private const string PLAYER_KEY = "PlayerObjString";
    public Player _player = null;


    public PlayerService()
    {
        string userString = PlayerPrefs.GetString(PLAYER_KEY, null);
        Debug.Log("userstring " + userString);

        if (!string.IsNullOrEmpty(userString) && !userString.Equals("null"))
        {
            _player = JsonUtility.FromJson<Player>(userString);
        }
        else
        {
            _player = new Player("Guest" + Random.Range(10000,99999), 0, 0, 0f, 0, 1, 5000);
            SaveUser();
        }
    }

    private void SaveUser(bool saveUserOnline = false)
    {

        PlayerPrefs.SetString(PLAYER_KEY, JsonUtility.ToJson(_player));

        if (saveUserOnline)
        {
            //Save User Online functionality will go here.
        }
    }

    public void ResetPlayer()
    {
        _player = new Player("Guest" + Random.Range(10000, 99999), 0, 0, 0f, 0, 1, 5000);
        SaveUser();
    }

    #region Public_API

    public void SetPlayerName(string name)
    {
        _player.playerName = name;
        SaveUser();
    }

    public string GetPlayerName()
    {
        return _player.playerName;
    }

    public void SetHighScore(int score)
    {
        _player.highScore = score;
        SaveUser();
    }

    public int GetHighScore()
    {
        return _player.highScore;
    }

    public void SetTotalScore(int score)
    {
        _player.totalScore = score;
        SaveUser();
    }

    public int GetTotalScore()
    {
        return _player.totalScore;
    }

    public void SetNumberOfGames(int count)
    {
        _player.numberOfGames += count;
        SaveUser();
    }

    public int GetNumberOfGames()
    {
        return _player.numberOfGames;
    }

    public void SetTimeSpent(float time)
    {
        _player.timeSpent += time;
        SaveUser();
    }

    public float GetTimeSpent()
    {
        return _player.timeSpent;
    }

    public void SetPlayerLevel(int level)
    {
        _player.level = level;
        SaveUser();
    }

    public void IncrementPlayerLevel(int level)
    {
        _player.level += level;
        SaveUser();
    }

    public int GetPlayerLevel()
    {
        return _player.level;
    }

    public void SetCoins(int coins)
    {
        _player.coins += coins;
        SaveUser();
    }

    public int GetPlayerCoins()
    {
        return _player.coins;
    }

    public void SetTutorial(bool isSeen)
    {
        _player.isTutorialSeen = isSeen;
    }

    public bool IsTutorialSeen()
    {
        return _player.isTutorialSeen;
    }
    #endregion
}