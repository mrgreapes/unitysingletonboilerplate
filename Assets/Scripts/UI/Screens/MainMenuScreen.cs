using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Button playBtn, quitBtn;
    void Start()
    {
        playBtn.onClick.AddListener(OnPlayClick);
        quitBtn.onClick.AddListener(OnQuitClick);

    }

    private void OnQuitClick()
    {
        Application.Quit();
    }

    private void OnPlayClick()
    {
        MainMenuController.Instance.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
