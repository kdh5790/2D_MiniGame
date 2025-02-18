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

    public IEnumerator OnNoticeTextCoroutine(string text, float time)
    {
        noticeText.text = text;

        yield return new WaitForSeconds(time);

        noticeText = null;
        gameObject.SetActive(false);
    }

    public void OnNoticeText(string text, float time)
    {
        StopAllCoroutines();
        gameObject.SetActive(true);
        StartCoroutine(OnNoticeTextCoroutine(text, time));
    }
}
