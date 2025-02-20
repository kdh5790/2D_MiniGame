using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNPC : NPC
{
    [SerializeField] private DialogueUI dialogueUI;

    public string npcName;
    public SpriteRenderer npcSprite; 

    [TextArea]
    [SerializeField] private string firstDialogue = string.Empty; // 첫 대사

    [TextArea]
    [SerializeField] private string choiceText1 = string.Empty; // 선택지
    [TextArea]
    [SerializeField] private string choiceText2 = string.Empty; 

    [TextArea]
    [SerializeField] private string answerDialogue1 = string.Empty; // 선택지에 대한 답변
    [TextArea]
    [SerializeField] private string answerDialogue2 = string.Empty;


    private void Start()
    {
        dialogueUI = FindObjectOfType<DialogueUI>(true);
        npcSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive && !dialogueUI.gameObject.activeSelf)
        {
            // 현재 활성화 상태이고 대화중이 아니라면
            dialogueUI.gameObject.SetActive(true);

            StartCoroutine(dialogueUI.TalkDialogue
                (firstDialogue, npcID,
                choiceText1, choiceText2));
        }
    }

    // 선택지에 대한 답변 반환
    public string GetAnswerDialogue(int num)
    {
        switch(num)
        {
            case 1:
                return answerDialogue1;

            case 2:
                return answerDialogue2;

            default:
                return string.Empty;
        }
    }
}
