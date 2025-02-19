using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;

    public List<DialogueNPC> dialogueNpcList;

    private void Awake()
    {
        if (instance == null)
        { instance = this; }
    }

    void Start()
    {
        dialogueNpcList = FindObjectsOfType<DialogueNPC>().ToList();
    }

    void Update()
    {
        
    }
}
