using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MakeTenScoreUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button returnLobbyButton;

    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        restartButton.onClick.AddListener(OnClickRestartButton);
        returnLobbyButton.onClick.AddListener(OnClickReturnLobbyButton);

        scoreText.text = MakeTen.instance.score.ToString();
    }

    private void OnClickRestartButton()
    {
        SceneManager.LoadScene((int)Scene.MakeTen);
    }

    private void OnClickReturnLobbyButton()
    {
        SceneManager.LoadScene((int)Scene.Lobby);
    }
}
