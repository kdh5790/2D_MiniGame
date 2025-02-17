using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class RankingManager : MonoBehaviour
{
    private const string RankingKey = "Ranking";

    public void AddScore()
    {
        int score = FindObjectOfType<TheStack>().Score;

        string jsonScores = PlayerPrefs.GetString(RankingKey, "[]");

        List<string> scoreList;

        scoreList = JsonUtility.FromJson<List<string>>(jsonScores);

        if (scoreList == null)
            scoreList = new List<string>();
        else
        {
            foreach (var data in scoreList)
                Debug.Log(data);
        }


        scoreList.Add(score.ToString());

        jsonScores = JsonUtility.ToJson(scoreList);
        PlayerPrefs.SetString(RankingKey, jsonScores);
    }
}
