using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance;

    public SplashScreen splashScreen;
    public LoadingScreen loadingScreen;
    public MainMenuScreen mainMenuScreen;
    public GameObject activeScreen;
    int sceneId;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetActiveScreen(splashScreen.gameObject);
    }

    public void LoadScene(int id)
    {
        sceneId = id;
        ShowLoadingScreen(NextSceneToLoad);
        //loadingScreen.OnLoadingComplete.AddListener(NextSceneToLoad);
    }


    public void SetActiveScreen(GameObject screen)
    {
        if (activeScreen)
        {
            activeScreen.SetActive(false);
        }
        activeScreen = screen;
        activeScreen.SetActive(true);
    }

    public void ShowLoadingScreen()
    {
        SetActiveScreen(loadingScreen.gameObject);
    }
    public void ShowLoadingScreen(UnityAction action)
    {
        loadingScreen.OnLoadingComplete = action;
        SetActiveScreen(loadingScreen.gameObject);
    }
    public void ShowMainMenuScreen()
    {
        SetActiveScreen(mainMenuScreen.gameObject);
    }

    void NextSceneToLoad()
    {
        SceneManager.LoadScene(sceneId);
    }
}
