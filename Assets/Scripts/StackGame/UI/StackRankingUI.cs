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
        // ���� ���ӿ�����Ʈ�� ��Ȱ��ȭ ���¶��
        if (!gameObject.activeSelf)
        {
            // ������Ʈ Ȱ��ȭ
            gameObject.SetActive(true);

            // GetRanking �Լ��� ���� PlayerPrefs�� ����� ������ ��������
            List<int> scores = FindObjectOfType<StackRankingManager>().GetRanking();

            // GetRanking�� ���� ������ ������ ���� scoreTextList�� ����(5) ���� ������ üũ
            int minCount = Mathf.Min(scores.Count, scoreTextList.Count);

            // TextUI�� ���� ����
            for (int i = 0; i < minCount; i++)
            {
                if (scores[i] != 0)
                    scoreTextList[i].text = scores[i].ToString();
                else
                    scoreTextList[i].text = "";
            }

            // minCount�� 5���� �۾Ҵٸ� �� ������ �ؽ�Ʈ�� �������� ����
            for(int i = minCount; i < scoreTextList.Count; i++)
            {
                scoreTextList[i].text = "";
            }
            
        }
        else
            gameObject.SetActive(false);
    }
}
