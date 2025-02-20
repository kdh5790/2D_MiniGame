using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    TextMeshProUGUI goldText;

    public Image characterFrameImage; // 정보 UI의 캐릭터 프레임 이미지
    public List<CharacterScriptableObject> charactersInfo; // 플레이어블 캐릭터들의 스크립트오브젝트 리스트
                                                           // Character enum(직업, 이름), 스프라이트, 초기 크기, 가격 

    private void Awake()
    {
        goldText = GetComponentInChildren<TextMeshProUGUI>();
        characterFrameImage = transform.Find("SpriteFrame").Find("PlayerSprite").GetComponent<Image>();
    }

    private void Start()
    {
        UpdateGoldText();
        ChangeCharacterFrameImage(Character.Knight);
    }

    public void UpdateGoldText()
    {
        goldText.text = GoldManager.instance.PlayerGold.ToString();
    }

    // 현재 캐릭터로 프레임 이미지 변경
    public void ChangeCharacterFrameImage(Character currentCharacter)
    {
        characterFrameImage.sprite = charactersInfo[(int)currentCharacter].sprite;
        characterFrameImage.gameObject.transform.localScale = charactersInfo[(int)currentCharacter].scale;
        characterFrameImage.SetNativeSize();
    }
}
