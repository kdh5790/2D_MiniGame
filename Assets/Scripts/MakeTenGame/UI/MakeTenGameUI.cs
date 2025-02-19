using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MakeTenGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        if(!MakeTen.instance.isDead)
        {
            UpdateText();
        }
    }
    public void UpdateText()
    {
        timeText.text = $"{MakeTen.instance.time.ToString("N2")}";
        scoreText.text = $"{MakeTen.instance.score}Á¡";
    }
}
