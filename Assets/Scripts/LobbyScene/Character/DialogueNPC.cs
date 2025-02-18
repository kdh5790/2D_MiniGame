using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : NPC
{
    [SerializeField] private GameObject dialogueUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            dialogueUI.gameObject.SetActive(true);
        }
    }

}
