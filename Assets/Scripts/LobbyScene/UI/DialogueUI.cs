using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DialogueUI : MonoBehaviour
{
    List<DialogueNPC> npcList;
    int npcID;
    TextMeshProUGUI dialogueText;

    [SerializeField] private Button choiceButton1;
    [SerializeField] private Button choiceButton2;
    [SerializeField] private Button closeButton;

    private void Start()
    {
        npcList = FindObjectsOfType<DialogueNPC>().ToList();
        choiceButton1.onClick.AddListener(OnClickChoiceButton1);
        choiceButton2.onClick.AddListener(OnClickChoiceButton2);
        closeButton.onClick.AddListener(OnClickCloseButton);
    }

    // text = 기본 대사, _npcID = 대화 중인 NPCID, choiceText = 선택지 (선택지 있을 때만 버튼 표시)
    public IEnumerator TalkDialogue(string text, int _npcID, string choiceText1 = "", string choiceText2 = "")
    {
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);

        if (dialogueText == null)
            dialogueText = transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();

        dialogueText.text = "";

        npcID = _npcID;

        for (int i = 0; i < text.Length; i++)
        {
            dialogueText.text += text[i];
            yield return new WaitForSeconds(0.03f);
        }

        if (choiceText1 != "")
        {
            choiceButton1.gameObject.SetActive(true);
            choiceButton1.GetComponentInChildren<TextMeshProUGUI>().text = choiceText1;
        }

        if (choiceText2 != "")
        {
            choiceButton2.gameObject.SetActive(true);
            choiceButton2.GetComponentInChildren<TextMeshProUGUI>().text = choiceText2;
        }

        if(!choiceButton1.gameObject.activeSelf && !choiceButton2.gameObject.activeSelf)
        {
            closeButton.gameObject.SetActive(true);
        }
    }

    private IEnumerator AnswerDialogue(string answer)
    {
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);

        dialogueText.text = string.Empty;

        for (int i = 0; i < answer.Length; i++)
        {
            dialogueText.text += answer[i];
            yield return new WaitForSeconds(0.03f);
        }

        closeButton.gameObject.SetActive(true);
    }

    private void OnClickChoiceButton1()
    {
        var _npc = npcList.Find(x => x.npcID == npcID).GetComponent<DialogueNPC>();
        string answer = _npc.GetAnswerDialogue(1);

        if (answer == string.Empty) return;

        StartCoroutine(AnswerDialogue(answer));
    }

    private void OnClickChoiceButton2()
    {
        var _npc = npcList.Find(x => x.npcID == npcID).GetComponent<DialogueNPC>();
        string answer = _npc.GetAnswerDialogue(2);

        if (answer == string.Empty) return;

        StartCoroutine(AnswerDialogue(answer));
    }

    private void OnClickCloseButton()
    {
        gameObject.SetActive(false);
    }
}
