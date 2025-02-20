using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;

    public List<DialogueNPC> dialogueNpcList; // 대화 가능 NPC 리스트

    private void Awake()
    {
        if (instance == null)
        { instance = this; }
    }

    void Start()
    {
        dialogueNpcList = FindObjectsOfType<DialogueNPC>().ToList();
    }
}
