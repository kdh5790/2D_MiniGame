using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    TextMeshProUGUI dialogueText;

    [SerializeField] private Button choiceButton1;
    [SerializeField] private Button choiceButton2;


    // text = 기본 대사, choiceText : 선택지 (선택지 있을 때만 버튼 표시)
    public IEnumerator DialogueText(string text, string choiceText1 = "", string choiceText2 = "")
    {
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);

        if (dialogueText == null)
            dialogueText = transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();

        dialogueText.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            dialogueText.text += text[i];
            yield return new WaitForSeconds(0.03f);
        }

        if(choiceText1 != "")
        {
            choiceButton1.gameObject.SetActive(true);
            choiceButton1.GetComponentInChildren<TextMeshProUGUI>().text = choiceText1;
        }

        if (choiceText2 != "")
        {
            choiceButton2.gameObject.SetActive(true);
            choiceButton2.GetComponentInChildren<TextMeshProUGUI>().text = choiceText2;
        }
    }
}
