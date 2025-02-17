using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneButton : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button exitBtn;

    private ScreenFader screenFader;

    private void Start()
    {
        startBtn.onClick.AddListener(OnClickStartButton);
        exitBtn.onClick.AddListener(OnClickExitButton);
        screenFader = FindObjectOfType<ScreenFader>();
    }

    void OnClickStartButton()
    {
        StartCoroutine(screenFader.FadeOutSceneChange(Scene.Lobby));
    }

    void OnClickExitButton()
    {
        Application.Quit();
    }
}
