using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleGameUI : MonoBehaviour
{
    ObstaclesBackGround backGround;
    PlayerController player;

    TextMeshProUGUI timeText;
    TextMeshProUGUI speedText;

    float time = 0f;

    void Start()
    {
        backGround = FindObjectOfType<ObstaclesBackGround>();
        player = FindObjectOfType<PlayerController>();

        timeText = transform.Find("TimeText").GetComponent<TextMeshProUGUI>();
        speedText = transform.Find("SpeedText").GetComponent<TextMeshProUGUI>();

        timeText.text = $"�ð�:{time}";
        speedText.text = $"";
    }

    void Update()
    {
        if (backGround.speed > 0 && !player.isDead)
        {
            time += Time.deltaTime;
            timeText.text = $"�ð�:{time.ToString("F2")}";

            speedText.text = $"�ӵ�:{backGround.speed.ToString("F1")}";
        }
    }
}
