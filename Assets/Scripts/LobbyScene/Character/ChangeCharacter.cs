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
    [SerializeField] private Animator[] charactersAnimator; // 플레이어블 캐릭터들의 애니메이터

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
            // 플레이어 캐릭터가 랜서라면 이전 캐릭터로 변경
            if (PlayerDataManager.instance.currentCharacter == Character.Lancer)
            {
                SpriteChange(PlayerDataManager.instance.returnCharacter);
                return;
            }

            // 랜서가 아니라면 랜서로 변경
            SpriteChange(Character.Lancer);
        }
    }

    public void SpriteChange(Character type)
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        if (player == null)
        { Debug.Log("PlayerController를 찾을 수 없습니다."); return; }

        // 캐릭터 보유여부 체크 (E키 입력 후 랜서 보유 중이 아닐 시 여기서 return)
        if (!PlayerDataManager.instance.unlockCharacters.Contains(type))
        {
            Debug.Log("현재 캐릭터를 보유하고 있지 않습니다.");
            return;
        }

        // 플레이어 애니메이터 변경
        Animator playerAnim = player.GetComponentInChildren<Animator>();

        playerAnim.runtimeAnimatorController = charactersAnimator[(int)type].runtimeAnimatorController;

        // 랜서라면 이동속도 증가
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
