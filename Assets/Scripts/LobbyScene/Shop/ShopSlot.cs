using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private CharacterScriptableObject characterInfo;

    bool isBuy;

    Character slotCharacter;

    Image characterImage;

    TextMeshProUGUI priceText;

    Button buyOrEquipButton;
    TextMeshProUGUI buyOrEquipText;

    private void Start()
    {
        characterImage = transform.Find("CharacterSprite").GetComponentInChildren<Image>();
        priceText = transform.Find("PriceBackGround").GetComponentInChildren<TextMeshProUGUI>();
        buyOrEquipButton = GetComponentInChildren<Button>();
        buyOrEquipText = buyOrEquipButton.GetComponentInChildren<TextMeshProUGUI>();

        SetSlot();
    }

    private void SetSlot()
    {
        slotCharacter = characterInfo.character;

        characterImage.sprite = characterInfo.sprite;
        characterImage.transform.localScale = characterInfo.scale;
        characterImage.SetNativeSize();

        priceText.text = $"{characterInfo.price.ToString()}G";

        if(PlayerDataManager.instance.unlockCharacters.Contains(slotCharacter))
        {
            buyOrEquipText.text = "장착하기";
            buyOrEquipButton.image.color = new Color(0, 0.7f, 1f, 1f);
        }
        else
        {
            buyOrEquipText.text = "구매하기";
            buyOrEquipButton.image.color = new Color(0, 1f, 0f, 1f);
        }
    }

}
