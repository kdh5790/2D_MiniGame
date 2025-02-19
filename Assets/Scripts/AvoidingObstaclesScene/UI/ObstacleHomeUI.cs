using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObstacleHomeUI : MonoBehaviour
{
    ObstaclesBackGround background;

    Button startButton;
    Button returnLobbyButton;

    void Start()
    {
        background = FindObjectOfType<ObstaclesBackGround>();
        background.speed = 0f;

        startButton = transform.Find("StartButton").GetComponent<Button>();
        returnLobbyButton = transform.Find("ReturnLobbyButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        returnLobbyButton.onClick.AddListener(OnClickReturnLobbyButton);
    }

    public void OnClickStartButton()
    {
        background.StartSpeedUpCorountine();
        FindObjectOfType<ObstacleGameUI>(true).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnClickReturnLobbyButton()
    {
        SceneManager.LoadScene((int)Scene.Lobby);
    }
}
