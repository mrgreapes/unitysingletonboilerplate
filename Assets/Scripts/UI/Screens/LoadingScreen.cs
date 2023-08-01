using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

    public Slider loadingSlider;
    public float timeToMove;
    public UnityAction OnLoadingComplete;
    public static bool isSplashLoading;
    // Start is called before the first frame update

    private void OnEnable()
    {
        loadingSlider.value = 0;
        if(!isSplashLoading)
        {
            LoadScreen();
        }
        else
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        loadingSlider.DOValue(1, timeToMove).OnComplete(delegate ()
        {
            OnLoadingComplete.Invoke();
        });
    }
    public void LoadScreen()
    {
        loadingSlider.DOValue(1, timeToMove).OnComplete(delegate ()
        {
            isSplashLoading = true;
            MainMenuController.Instance.ShowMainMenuScreen();
        });
    }
}
