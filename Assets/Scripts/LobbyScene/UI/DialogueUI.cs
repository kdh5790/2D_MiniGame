using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    DialogueNPC currentNpc;
    int npcID; // ���� ��ȭ ���� NPC�� �Ǵ��� ID

    TextMeshProUGUI dialogueText; // ���(��簡 ��������� List�� �迭�� �ٲ㵵 �� ��?)
    Image npcImage; // NPC ��������Ʈ(�̹���)
    TextMeshProUGUI npcNameText; // NPC �̸�

    [SerializeField] private Button choiceButton1; // ��������ư 1
    [SerializeField] private Button choiceButton2; // ��������ư 2
    [SerializeField] private Button closeButton;

    private void Start()
    {
        choiceButton1.onClick.AddListener(OnClickChoiceButton1);
        choiceButton2.onClick.AddListener(OnClickChoiceButton2);
        closeButton.onClick.AddListener(OnClickCloseButton);

        npcImage = transform.Find("NPCInfo").GetComponentInChildren<Image>(true);
        npcNameText = transform.Find("NPCInfo").GetComponentInChildren<TextMeshProUGUI>(true);
    }

    private void OnEnable()
    {
        npcImage = transform.Find("NPCInfo").GetComponentInChildren<Image>(true);
        npcNameText = transform.Find("NPCInfo").GetComponentInChildren<TextMeshProUGUI>(true);
    }

    // text = �⺻ ���, _npcID = ��ȭ ���� NPCID, choiceText = ������ (������ ���� ���� ��ư ǥ��)
    public IEnumerator TalkDialogue(string text, int _npcID, string choiceText1 = "", string choiceText2 = "")
    {
        npcID = _npcID;

        // NPC ��Ͽ��� ���� ��ȭ ���� NPC�� ������
        currentNpc = NPCManager.instance.dialogueNpcList.Find(x => x.npcID == npcID).GetComponent<DialogueNPC>();

        npcImage.sprite = currentNpc.npcSprite.sprite;
        npcNameText.text = currentNpc.npcName;

        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);

        if (dialogueText == null)
            dialogueText = transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();

        dialogueText.text = "";


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
        string answer = currentNpc.GetAnswerDialogue(1);

        if (answer == string.Empty) return;

        StartCoroutine(AnswerDialogue(answer));
    }

    private void OnClickChoiceButton2()
    {
        string answer = currentNpc.GetAnswerDialogue(2);

        if (answer == string.Empty) return;

        StartCoroutine(AnswerDialogue(answer));
    }

    private void OnClickCloseButton()
    {
        gameObject.SetActive(false);
    }
}
