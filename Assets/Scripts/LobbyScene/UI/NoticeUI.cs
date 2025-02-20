using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NoticeUI : MonoBehaviour
{
    TextMeshProUGUI noticeText;

    private void Awake()
    {
        noticeText = GetComponentInChildren<TextMeshProUGUI>(true);
    }

    // �Ű����� text�� ���ڿ��� time��(�ð�) ��ŭ ǥ��
    public IEnumerator OnNoticeTextCoroutine(string text, float time)
    {
        noticeText.text = text;

        yield return new WaitForSeconds(time);

        noticeText.text = string.Empty;
        gameObject.SetActive(false);
    }

    public void OnNoticeText(string text, float time)
    {
        StopAllCoroutines();
        gameObject.SetActive(true);
        StartCoroutine(OnNoticeTextCoroutine(text, time));
    }
}
