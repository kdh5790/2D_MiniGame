using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;

// JsonUtility로 직렬화 하기 위한 래퍼클래스
// JsonUtility에서는 List를 직접 직렬화 하지 못하기 때문에 래퍼클래스로 묶어서 사용
public class ScoreList
{
    public List<string> scores = new List<string>();
}

public class StackRankingManager : MonoBehaviour
{
    // 랭킹 점수를 저장할 PlayerPrefs 키 
    private const string StackRankingKey = "StackRanking";

    // 최대로 표시할 점수 갯수 
    private const int maxRanking = 5;

    public void AddScore()
    {
        // 현재 점수 가져오기
        int score = FindObjectOfType<TheStack>().Score;

        // 랭킹에 등록된 점수들 가져오기
        string jsonScores = PlayerPrefs.GetString(StackRankingKey, JsonUtility.ToJson(new ScoreList()));

        // 가져온 점수들을 JsounUtillity를 사용해 역직렬화 후 ScoreList로 변환
        ScoreList scoreListWrapper = JsonUtility.FromJson<ScoreList>(jsonScores);

        // 가져온 점수가 없다면(등록된 점수가 없다면) 래퍼 클래스 새로 생성
        if (scoreListWrapper == null)
                scoreListWrapper = new ScoreList();

        // 점수를 저장할 변수에 현재 스코어 추가
        scoreListWrapper.scores.Add(score.ToString());

        // 저장된 점수들 Json 형식으로 변경 
        jsonScores = JsonUtility.ToJson(scoreListWrapper);

        // PlayerPrefs에 저장
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

        // 가져온 점수 리스트를 내림차순으로 정렬 후 상위 5개의 점수만 가져와 리스트에 저장
        rankingList = rankingList.OrderByDescending(s => s).Take(maxRanking).ToList();

        return rankingList;
    }
}
