using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleGameUI : MonoBehaviour
{
    ObstaclesBackGround backGround;
    PlayerController player;

    TextMeshProUGUI bestTimeText;
    TextMeshProUGUI timeText;
    TextMeshProUGUI speedText;

    public float time = 0f;
    public float bestTime = 0f;

    private const string BestTimeKey = "BestTime";

    void Start()
    {
        backGround = FindObjectOfType<ObstaclesBackGround>();
        player = FindObjectOfType<PlayerController>();

        bestTimeText = transform.Find("BestTimeText").GetComponent<TextMeshProUGUI>();
        timeText = transform.Find("TimeText").GetComponent<TextMeshProUGUI>();
        speedText = transform.Find("SpeedText").GetComponent<TextMeshProUGUI>();

        bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);

        bestTimeText.text = $"최고기록:{bestTime.ToString("F2")}";
        timeText.text = $"시간:{time.ToString("F2")}";
        speedText.text = $"";

    }

    void Update()
    {
        if (backGround.speed > 0 && !player.isDead)
        {
            time += Time.deltaTime;
            if (time > bestTime)
            {
                bestTimeText.text = $"최고기록:{time.ToString("F2")}";
                PlayerPrefs.SetFloat(BestTimeKey, time);
            }
            timeText.text = $"시간:{time.ToString("F2")}";

            speedText.text = $"속도:{backGround.speed.ToString("F1")}";
        }
    }
}
