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
        // 버튼에 클릭 시 실행 할 함수 추가
        startBtn.onClick.AddListener(OnClickStartButton);
        exitBtn.onClick.AddListener(OnClickExitButton);

        screenFader = FindObjectOfType<ScreenFader>();
    }

    void OnClickStartButton()
    {
        // FadeOut 코루틴 실행
        StartCoroutine(screenFader.FadeOutSceneChange(Scene.Lobby));
    }

    void OnClickExitButton()
    {
        Application.Quit();
    }
}
