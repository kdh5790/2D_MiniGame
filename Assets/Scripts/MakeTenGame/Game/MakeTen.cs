using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTen : MonoBehaviour
{
    public static MakeTen instance;

    public List<GameObject> selectedNumber = new List<GameObject>();
    public int sum;

    public float time;
    public int score;

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
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

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
