using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public enum Character
{
    Knight,
    SwordsMan,
    Lancer
}

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField] private Animator[] charactersAnimator;

    public Character characterType = Character.Knight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SpriteChange(Character.Lancer);
        }
    }

    public void SpriteChange(Character type)
    {

        PlayerController player = FindObjectOfType<PlayerController>();

        if (player == null)
        { Debug.Log("PlayerController를 찾을 수 없습니다."); return; }

        Animator playerAnim = player.GetComponentInChildren<Animator>();

        playerAnim.runtimeAnimatorController = charactersAnimator[(int)type].runtimeAnimatorController;

        if (type == Character.Lancer)
            player.moveSpeed = 5f;
        else
            player.moveSpeed = 3f;

        characterType = type;
    }
}
