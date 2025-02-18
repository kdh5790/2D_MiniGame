using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : NPC
{
    [SerializeField] private DialogueUI dialogueUI;

    private void Start()
    {
        dialogueUI = FindObjectOfType<DialogueUI>(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            dialogueUI.gameObject.SetActive(true);
            StartCoroutine(dialogueUI.DialogueText
                ("안녕하세요 궁금하신게 있으시다면\r\n오른쪽 버튼을 클릭해 질문해 주시면\r\n답변해드리도록 하겠습니다.",
                "골드를 획득하는 \r\n방법을 알고 싶어요", "로비에서 이동하는게 \r\n너무 답답해요"));
        }
    }

}
