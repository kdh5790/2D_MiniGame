using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ShopSlotState
{
    Buy,
    Equip
}

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private CharacterScriptableObject characterInfo; // 구매 가능한 캐릭터 정보

    Character slotCharacter; // 현재 슬롯의 캐릭터

    Image characterImage;

    TextMeshProUGUI priceText;

    Button buyOrEquipButton;
    TextMeshProUGUI buyOrEquipText;

    PlayerInfoUI playerInfoUI;
    ShopUI shopUI;

    private void Start()
    {
        characterImage = transform.Find("CharacterSprite").GetComponentInChildren<Image>();
        priceText = transform.Find("PriceBackGround").GetComponentInChildren<TextMeshProUGUI>();
        buyOrEquipButton = GetComponentInChildren<Button>();
        buyOrEquipText = buyOrEquipButton.GetComponentInChildren<TextMeshProUGUI>();

        playerInfoUI = FindObjectOfType<PlayerInfoUI>();
        shopUI = FindObjectOfType<ShopUI>();
        SetSlot();
    }

    private void SetSlot()
    {
        // 슬롯 스프라이트, 크기 설정
        slotCharacter = characterInfo.character;

        characterImage.sprite = characterInfo.sprite;
        characterImage.transform.localScale = characterInfo.scale;
        characterImage.SetNativeSize();
        buyOrEquipButton.onClick.RemoveAllListeners();

        priceText.text = $"{characterInfo.price.ToString()}G";

        // 보유 여부에 따라 상태 변경
        if (!PlayerDataManager.instance.unlockCharacters.Contains(slotCharacter))
        {
            ChangeState(ShopSlotState.Buy);
        }
        else
        {
            ChangeState(ShopSlotState.Equip);
        }
    }

    private void ChangeState(ShopSlotState state)
    {
        switch (state)
        {
            case ShopSlotState.Equip:
                buyOrEquipText.text = "장착하기";
                buyOrEquipButton.image.color = new Color(0, 0.7f, 1f, 1f);
                buyOrEquipButton.onClick.RemoveAllListeners();
                buyOrEquipButton.onClick.AddListener(Equip);
                break;

            case ShopSlotState.Buy:
                buyOrEquipText.text = "구매하기";
                buyOrEquipButton.image.color = new Color(0, 1f, 0f, 1f);
                buyOrEquipButton.onClick.RemoveAllListeners();
                buyOrEquipButton.onClick.AddListener(Buy);
                break;
        }
    }

    private void Buy()
    {
        if (GoldManager.instance.PlayerGold >= characterInfo.price)
        {
            if (!PlayerDataManager.instance.unlockCharacters.Contains(slotCharacter))
            {
                // 알림 메세지 출력
                FindObjectOfType<NoticeUI>(true).OnNoticeText($"{characterInfo.name} 캐릭터를\n구매하였습니다.", 2f);

                // 해금한 캐릭터 목록에 추가
                PlayerDataManager.instance.unlockCharacters.Add(slotCharacter);

                // 골드 감소
                GoldManager.instance.PlayerGold -= characterInfo.price;
                playerInfoUI.UpdateGoldText();

                // 버튼을 장착하기로 변경
                ChangeState(ShopSlotState.Equip);

                return;
            }
            else
            {
                FindObjectOfType<NoticeUI>(true).OnNoticeText($"이미 구입한 캐릭터입니다.", 2f);
            }
        }
        else
        {
            FindObjectOfType<NoticeUI>(true).OnNoticeText("골드가 부족합니다", 2f);
            return;
        }

    }

    private void Equip()
    {
        // 현재 슬롯의 캐릭터가 플레이어의 캐릭터와 다르다면 변경
        if (slotCharacter != PlayerDataManager.instance.currentCharacter)
        {
            FindAnyObjectByType<ChangeCharacter>().SpriteChange(slotCharacter);
            shopUI.ChangeSprite();
        }
    }
}
