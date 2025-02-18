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
                ("�ȳ��ϼ��� �ñ��ϽŰ� �����ôٸ�\r\n������ ��ư�� Ŭ���� ������ �ֽø�\r\n�亯�ص帮���� �ϰڽ��ϴ�.",
                "��带 ȹ���ϴ� \r\n����� �˰� �;��", "�κ񿡼� �̵��ϴ°� \r\n�ʹ� ����ؿ�"));
        }
    }

}
