using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObstacleScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI bestTimeText;

    [SerializeField] private Button RestartButton;
    [SerializeField] private Button ReturnHomeButton;

    void Start()
    {
        RestartButton.onClick.AddListener(OnClickRestartButton);
        ReturnHomeButton.onClick.AddListener(OnClickReturnHomeButton);
    }

    private void OnClickRestartButton()
    {
        SceneManager.LoadScene((int)Scene.Obstacle);
        FindObjectOfType<ObstacleHomeUI>(true).OnClickStartButton();
    }

    private void OnClickReturnHomeButton()
    {
        SceneManager.LoadScene((int)Scene.Obstacle);
    }

    public void SetScore(float time)
    {
        timeText.text = time.ToString("N2");
        bestTimeText.text = time.ToString("N2");
    }
}
