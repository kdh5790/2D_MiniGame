using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MakeTenHomeUI : MonoBehaviour
{
    private Button startButton;
    private Button returnLobbyButton;

    private InitializeNumber initializeNumber;

    void Start()
    {
        startButton = transform.Find("StartButton").GetComponent<Button>();
        returnLobbyButton = transform.Find("ReturnLobbyButton").GetComponent<Button>();

        initializeNumber = FindObjectOfType<InitializeNumber>();

        startButton.onClick.AddListener(OnClickStartButton);
        returnLobbyButton.onClick.AddListener(OnClickReturnLobbyButton);
    }

    private void OnClickStartButton()
    {
        MakeTen.instance.isDead = false;
        initializeNumber.InitializePannel();
        gameObject.SetActive(false);
    }

    private void OnClickReturnLobbyButton()
    {
        SceneManager.LoadScene((int)Scene.Lobby);
    }
}
