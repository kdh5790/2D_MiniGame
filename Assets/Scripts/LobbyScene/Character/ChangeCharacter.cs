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
    [SerializeField] private Animator[] charactersAnimator; // �÷��̾�� ĳ���͵��� �ִϸ�����

    private void Start()
    {
        if (PlayerDataManager.instance.currentCharacter == Character.Lancer)
            SpriteChange(PlayerDataManager.instance.returnCharacter);
        else
            SpriteChange(PlayerDataManager.instance.currentCharacter);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �÷��̾� ĳ���Ͱ� ������� ���� ĳ���ͷ� ����
            if (PlayerDataManager.instance.currentCharacter == Character.Lancer)
            {
                SpriteChange(PlayerDataManager.instance.returnCharacter);
                return;
            }

            // ������ �ƴ϶�� ������ ����
            SpriteChange(Character.Lancer);
        }
    }

    public void SpriteChange(Character type)
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        if (player == null)
        { Debug.Log("PlayerController�� ã�� �� �����ϴ�."); return; }

        // ĳ���� �������� üũ (EŰ �Է� �� ���� ���� ���� �ƴ� �� ���⼭ return)
        if (!PlayerDataManager.instance.unlockCharacters.Contains(type))
        {
            Debug.Log("���� ĳ���͸� �����ϰ� ���� �ʽ��ϴ�.");
            return;
        }

        // �÷��̾� �ִϸ����� ����
        Animator playerAnim = player.GetComponentInChildren<Animator>();

        playerAnim.runtimeAnimatorController = charactersAnimator[(int)type].runtimeAnimatorController;

        // ������� �̵��ӵ� ����
        if (type == Character.Lancer && PlayerDataManager.instance.currentCharacter != Character.Lancer)
        {
            PlayerDataManager.instance.returnCharacter = PlayerDataManager.instance.currentCharacter;
            player.moveSpeed = 5f;
        }
        else
            player.moveSpeed = 3f;

        FindObjectOfType<PlayerInfoUI>().ChangeCharacterFrameImage(type);

        PlayerDataManager.instance.currentCharacter = type;
    }
}
