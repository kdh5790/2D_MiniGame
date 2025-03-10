using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    Button closeButton;

    Image colorCharacterImage;
    PlayerInfoUI playerInfo;

    bool isFirstOpen = true;

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfoUI>();

        ChangeSprite();

        closeButton = transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(CloseShopUI);
        isFirstOpen = false;
    }

    public void OpenShopUI()
    {
        gameObject.SetActive(true);
        if (!isFirstOpen)
            ChangeSprite();
    }

    public void CloseShopUI()
    {
        gameObject.SetActive(false);
    }

    // 색상변경 UI에 있는 캐릭터 프레임 변경
    public void ChangeSprite()
    {
        colorCharacterImage = transform.Find("CharacterFrame").GetComponent<Image>();
        colorCharacterImage.sprite = playerInfo.characterFrameImage.sprite;
        colorCharacterImage.SetNativeSize();
    }
}
