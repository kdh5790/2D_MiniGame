using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;

    public int PlayerGold { get; set; }
    public int MiniGameGold { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void InitializeMiniGameGold()
    {
        MiniGameGold = 0;
    }

    public void AddMiniGameGold(int score)
    {
        MiniGameGold += score;
    }

    public void AddPlayerGold()
    {
        PlayerGold += MiniGameGold;
    }
}
