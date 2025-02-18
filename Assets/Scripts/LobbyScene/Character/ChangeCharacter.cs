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
    public Character returnCharacter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(characterType == Character.Lancer)
            {
                SpriteChange(returnCharacter);
                return;
            }
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
        {
            returnCharacter = characterType;
            player.moveSpeed = 5f;
        }
        else
            player.moveSpeed = 3f;

        FindObjectOfType<PlayerInfoUI>().ChangeCharacterFrameImage(type);

        characterType = type;
    }
}
