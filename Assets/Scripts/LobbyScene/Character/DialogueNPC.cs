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
    [SerializeField] private string firstDialogue = string.Empty;

    [TextArea]
    [SerializeField] private string choiceText1 = string.Empty;
    [TextArea]
    [SerializeField] private string choiceText2 = string.Empty;

    [TextArea]
    [SerializeField] private string answerDialogue1 = string.Empty;
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
            dialogueUI.gameObject.SetActive(true);
            StartCoroutine(dialogueUI.TalkDialogue
                (firstDialogue, npcID,
                choiceText1, choiceText2));
        }
    }

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
