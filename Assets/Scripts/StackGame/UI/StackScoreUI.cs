using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StackScoreUI : StackBaseUI
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI comboText;
    TextMeshProUGUI bestScoreText;
    TextMeshProUGUI bestComboText;

    Button startBtn;
    Button exitBtn;
    Button saveScoreBtn;

    protected override UIState GetUIState()
    {
        return UIState.Score;
    }

    public override void Init(StackUIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
        bestComboText = transform.Find("BestComboText").GetComponent<TextMeshProUGUI>();

        startBtn = transform.Find("StartButton").GetComponent<Button>();
        exitBtn = transform.Find("ExitButton").GetComponent<Button>();
        saveScoreBtn = transform.Find("SaveScoreButton").GetComponent<Button>();

        startBtn.onClick.AddListener(OnClickStartButton);
        exitBtn.onClick.AddListener(OnClickRestartButton);
        saveScoreBtn.onClick.AddListener(OnClickSaveScoreButton);
    }

    public void SetUI(int score, int combo, int bestScore, int bestCombo)
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
        bestScoreText.text = bestScore.ToString();
        bestComboText.text = bestCombo.ToString();

        // �̴ϰ��� �� ȹ���� ���� ��忡 �߰�
        GoldManager.instance.AddMiniGameGold(score);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void OnClickRestartButton()
    {
        SceneManager.LoadScene((int)Scene.Stack);
    }

    void OnClickSaveScoreButton()
    {
        FindObjectOfType<StackRankingManager>().AddScore();
    }
}
