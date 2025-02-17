using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class ScoreList
{
    public List<string> scores = new List<string>();
}

public class RankingManager : MonoBehaviour
{
    private const string StackRankingKey = "StackRanking";
    private const int maxRanking = 5;

    public void AddScore()
    {
        int score = FindObjectOfType<TheStack>().Score;

        string jsonScores = PlayerPrefs.GetString(StackRankingKey, JsonUtility.ToJson(new ScoreList()));

        ScoreList scoreListWrapper = JsonUtility.FromJson<ScoreList>(jsonScores);

        if (scoreListWrapper == null)
                scoreListWrapper = new ScoreList();


        scoreListWrapper.scores.Add(score.ToString());

        jsonScores = JsonUtility.ToJson(scoreListWrapper);
        PlayerPrefs.SetString(StackRankingKey, jsonScores);
    }

    public List<int> GetRanking()
    {
        string jsonScores = PlayerPrefs.GetString(StackRankingKey, JsonUtility.ToJson(new ScoreList()));

        ScoreList scoreListWrapper = JsonUtility.FromJson<ScoreList>(jsonScores);

        List<int> rankingList = new List<int>();

        foreach (var data in scoreListWrapper.scores)
        {
            rankingList.Add(int.Parse(data));
        }

        rankingList = rankingList.OrderByDescending(s => s).Take(maxRanking).ToList();

        return rankingList;
    }
}
