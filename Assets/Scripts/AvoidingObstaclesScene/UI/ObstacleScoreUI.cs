using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObstacleScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI bestTimeText;

    [SerializeField] private Button RestartButton;
    [SerializeField] private Button returnLobbyButton;

    public List<ObstacleCreator> obstacleCreatorList;

    private const string BestTimeKey = "BestTime";

    void Start()
    {
        RestartButton.onClick.AddListener(OnClickRestartButton);
        returnLobbyButton.onClick.AddListener(OnClickReturnLobbyButton);

        obstacleCreatorList = FindObjectsOfType<ObstacleCreator>(true).ToList();
    }

    private void OnClickRestartButton()
    {
        SceneManager.LoadScene((int)Scene.Obstacle);
    }

    private void OnClickReturnLobbyButton()
    {
        SceneManager.LoadScene((int)Scene.Lobby);
    }

    public void SetScore(float time)
    {
        timeText.text = time.ToString("N2");
        float bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0);
        bestTimeText.text = bestTime.ToString("N2");

        GoldManager.instance.MiniGameGold += (int)time;
    }
}
