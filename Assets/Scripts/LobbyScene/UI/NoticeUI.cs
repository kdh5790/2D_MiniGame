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

    public IEnumerator OnNoticeText(string text, float time)
    {
        gameObject.SetActive(true);
        noticeText.text = text;

        yield return new WaitForSeconds(time);

        noticeText = null;
        gameObject.SetActive(false);
    }
}
