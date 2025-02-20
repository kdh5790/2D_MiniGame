using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Home,
    Game,
    Score
}

public class StackUIManager : MonoBehaviour
{
    static StackUIManager instance;

    public static StackUIManager Instance { get { return instance; } }

    UIState currentState = UIState.Home;

    // 현재 Scene에서 사용중인 UI 관련 클래스
    StackHomeUI homeUI = null;
    StackGameUI gameUI = null;
    StackScoreUI scoreUI = null;

    TheStack theStack = null;

    private void Awake()
    {
        instance = this;
        theStack = FindObjectOfType<TheStack>();

        // 현재 Scene에서 사용중인 UI 관련 클래스들 가져오기
        homeUI = GetComponentInChildren<StackHomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<StackGameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<StackScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        // 현재 상태에 따라 UI 활성화 및 비활성화
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene((int)Scene.Lobby);
    }
    
    public void UpdateScore()
    {
        gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);
        ChangeState(UIState.Score);
    }
}
