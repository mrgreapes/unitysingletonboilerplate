using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfilePopup : MonoBehaviour
{
    public TextMeshProUGUI playerName, playerLevel;
    PlayerService _playerService;
    // Start is called before the first frame update
    void Start()
    {
        _playerService = Services.PlayerService;
        playerName.text = _playerService.GetPlayerName();
        playerLevel.text = _playerService.GetPlayerLevel().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
