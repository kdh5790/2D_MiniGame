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

    public Character currentCharacter = Character.Knight;
    public Character returnCharacter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentCharacter == Character.Lancer)
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
        { Debug.Log("PlayerController�� ã�� �� �����ϴ�."); return; }

        if (!PlayerDataManager.instance.unlockCharacters.Contains(type))
        {
            Debug.Log("���� ĳ���͸� �����ϰ� ���� �ʽ��ϴ�.");
            return;
        }

        Animator playerAnim = player.GetComponentInChildren<Animator>();

        playerAnim.runtimeAnimatorController = charactersAnimator[(int)type].runtimeAnimatorController;

        if (type == Character.Lancer)
        {
            returnCharacter = currentCharacter;
            player.moveSpeed = 5f;
        }
        else
            player.moveSpeed = 3f;

        FindObjectOfType<PlayerInfoUI>().ChangeCharacterFrameImage(type);

        currentCharacter = type;
        PlayerDataManager.instance.currentCharacter = currentCharacter;
    }
}
