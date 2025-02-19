using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackHomeUI : StackBaseUI
{
    Button startBtn;
    Button exitBtn;
    Button rankingBtn;

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }

    public override void Init(StackUIManager uiManager)
    {
        base.Init(uiManager);

        startBtn = transform.Find("StartButton").GetComponent<Button>();
        exitBtn = transform.Find("ExitButton").GetComponent<Button>();
        rankingBtn = transform.Find("RankingButton").GetComponent<Button>();

        startBtn.onClick.AddListener(OnClickStartButton);
        exitBtn.onClick.AddListener(OnClickExitButton);
        rankingBtn.onClick.AddListener(OnClickRankingButton);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }

    void OnClickRankingButton()
    {
        FindObjectOfType<StackRankingUI>(true).OnRanikngBoard();
    }
}
