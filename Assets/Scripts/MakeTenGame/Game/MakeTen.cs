using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTen : MonoBehaviour
{
    public static MakeTen instance;

    public List<GameObject> selectedNumber = new List<GameObject>();
    public int sum; // 현재 드래그 박스에 들어온 숫자의 총합

    public float time; // 제한시간
    public int score; // 점수

    public bool isDead = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        sum = 0;
        time = 100f;
    }

    private void Update()
    {
        // 시간 감소
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

        // 시간이 0이라면 게임오버, ScoreUI 켜주기
        if (time < 0)
        {
            time = 0;
            isDead = true;

            if (GoldManager.instance != null)
                GoldManager.instance.MiniGameGold += score;

            FindObjectOfType<MakeTenGameUI>().gameObject.SetActive(false);
            FindObjectOfType<MakeTenScoreUI>(true).gameObject.SetActive(true);
        }
    }
}
