using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    NoticeUI notice;

    private void Start()
    {
        notice = FindObjectOfType<NoticeUI>(true);

        // �̴ϰ������� ���� ��带 �÷��̾� ��忡 �߰�
        if (GoldManager.instance.MiniGameGold != 0)
        {
            string text = $"�̴ϰ��� �� ȹ���� ���� ��ŭ\r\n��带 ȹ���߽��ϴ�.\r\n\r\nȹ���� ��� : {GoldManager.instance.MiniGameGold}G\r\n";
            notice.OnNoticeText(text, 2f);

            GoldManager.instance.AddPlayerGold();
            GoldManager.instance.InitializeMiniGameGold();
        }
    }
}
