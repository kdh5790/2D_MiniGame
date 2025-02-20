using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackRankingUI : StackBaseUI
{
    [SerializeField] private List<TextMeshProUGUI> scoreTextList = new List<TextMeshProUGUI>();

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }

    public override void Init(StackUIManager uiManager)
    {
        base.Init(uiManager);
    }

    public void OnRanikngBoard()
    {
        // 현재 게임오브젝트가 비활성화 상태라면
        if (!gameObject.activeSelf)
        {
            // 오브젝트 활성화
            gameObject.SetActive(true);

            // GetRanking 함수를 통해 PlayerPrefs에 저장된 점수들 가져오기
            List<int> scores = FindObjectOfType<StackRankingManager>().GetRanking();

            // GetRanking을 통해 가져온 점수의 수가 scoreTextList의 개수(5) 보다 낮은지 체크
            int minCount = Mathf.Min(scores.Count, scoreTextList.Count);

            // TextUI에 점수 적용
            for (int i = 0; i < minCount; i++)
            {
                if (scores[i] != 0)
                    scoreTextList[i].text = scores[i].ToString();
                else
                    scoreTextList[i].text = "";
            }

            // minCount가 5보다 작았다면 그 이후의 텍스트들 공백으로 변경
            for(int i = minCount; i < scoreTextList.Count; i++)
            {
                scoreTextList[i].text = "";
            }
            
        }
        else
            gameObject.SetActive(false);
    }
}
