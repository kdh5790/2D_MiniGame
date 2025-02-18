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
    [SerializeField] private CharacterScriptableObject characterInfo;

    Character slotCharacter;
    ShopSlotState currentState;

    Image characterImage;

    TextMeshProUGUI priceText;

    Button buyOrEquipButton;
    TextMeshProUGUI buyOrEquipText;

    PlayerInfoUI playerInfoUI;

    private void Start()
    {
        characterImage = transform.Find("CharacterSprite").GetComponentInChildren<Image>();
        priceText = transform.Find("PriceBackGround").GetComponentInChildren<TextMeshProUGUI>();
        buyOrEquipButton = GetComponentInChildren<Button>();
        buyOrEquipText = buyOrEquipButton.GetComponentInChildren<TextMeshProUGUI>();

        playerInfoUI = FindObjectOfType<PlayerInfoUI>();

        SetSlot();
    }

    private void SetSlot()
    {
        slotCharacter = characterInfo.character;

        characterImage.sprite = characterInfo.sprite;
        characterImage.transform.localScale = characterInfo.scale;
        characterImage.SetNativeSize();
        buyOrEquipButton.onClick.RemoveAllListeners();

        priceText.text = $"{characterInfo.price.ToString()}G";

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
                currentState = ShopSlotState.Equip;
                break;

            case ShopSlotState.Buy:
                buyOrEquipText.text = "구매하기";
                buyOrEquipButton.image.color = new Color(0, 1f, 0f, 1f);
                buyOrEquipButton.onClick.RemoveAllListeners();
                buyOrEquipButton.onClick.AddListener(Buy);
                currentState = ShopSlotState.Buy;
                break;
        }
    }

    private void Buy()
    {
        if (GoldManager.instance.PlayerGold > characterInfo.price)
        {
            if (!PlayerDataManager.instance.unlockCharacters.Contains(slotCharacter))
            {
                FindObjectOfType<NoticeUI>(true).OnNoticeText($"{characterInfo.name} 캐릭터를\n구매하였습니다.", 2f);
                PlayerDataManager.instance.unlockCharacters.Add(slotCharacter);
                GoldManager.instance.PlayerGold -= characterInfo.price;
                playerInfoUI.UpdateGoldText();

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
        FindAnyObjectByType<ChangeCharacter>().SpriteChange(slotCharacter);
    }
}
