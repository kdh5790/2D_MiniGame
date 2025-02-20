using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;

// JsonUtility�� ����ȭ �ϱ� ���� ����Ŭ����
// JsonUtility������ List�� ���� ����ȭ ���� ���ϱ� ������ ����Ŭ������ ��� ���
public class ScoreList
{
    public List<string> scores = new List<string>();
}

public class StackRankingManager : MonoBehaviour
{
    // ��ŷ ������ ������ PlayerPrefs Ű 
    private const string StackRankingKey = "StackRanking";

    // �ִ�� ǥ���� ���� ���� 
    private const int maxRanking = 5;

    public void AddScore()
    {
        // ���� ���� ��������
        int score = FindObjectOfType<TheStack>().Score;

        // ��ŷ�� ��ϵ� ������ ��������
        string jsonScores = PlayerPrefs.GetString(StackRankingKey, JsonUtility.ToJson(new ScoreList()));

        // ������ �������� JsounUtillity�� ����� ������ȭ �� ScoreList�� ��ȯ
        ScoreList scoreListWrapper = JsonUtility.FromJson<ScoreList>(jsonScores);

        // ������ ������ ���ٸ�(��ϵ� ������ ���ٸ�) ���� Ŭ���� ���� ����
        if (scoreListWrapper == null)
                scoreListWrapper = new ScoreList();

        // ������ ������ ������ ���� ���ھ� �߰�
        scoreListWrapper.scores.Add(score.ToString());

        // ����� ������ Json �������� ���� 
        jsonScores = JsonUtility.ToJson(scoreListWrapper);

        // PlayerPrefs�� ����
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

        // ������ ���� ����Ʈ�� ������������ ���� �� ���� 5���� ������ ������ ����Ʈ�� ����
        rankingList = rankingList.OrderByDescending(s => s).Take(maxRanking).ToList();

        return rankingList;
    }
}
