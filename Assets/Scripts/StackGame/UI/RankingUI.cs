using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingUI : BaseUI
{
    [SerializeField] private List<TextMeshProUGUI> rankingTextList = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> scoreTextList = new List<TextMeshProUGUI>();

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
    }

    public void OnRanikngBoard()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);

            List<int> scores = FindObjectOfType<RankingManager>().GetRanking();

            int minCount = Mathf.Min(scores.Count, scoreTextList.Count);

            for (int i = 0; i < minCount; i++)
            {
                if (scores[i] != 0)
                    scoreTextList[i].text = scores[i].ToString();
                else
                    scoreTextList[i].text = "";
            }

            for(int i = minCount; i < scoreTextList.Count; i++)
            {
                scoreTextList[i].text = "";
            }
        }
        else
            gameObject.SetActive(false);
    }
}
