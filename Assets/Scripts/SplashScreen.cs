using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{

    public RectTransform splashText;
    public float timeToMove = 2;
    public UnityEvent action;
    private void Start()
    {
        splashText.DOScale(new Vector3(1f, 1f, 1f), timeToMove).OnComplete(delegate (){
            MainMenuController.Instance.Invoke(nameof(MainMenuController.Instance.ShowLoadingScreen),1);
        });
    }
    public void NextScreen()
    {
        action.Invoke();
    }
}
