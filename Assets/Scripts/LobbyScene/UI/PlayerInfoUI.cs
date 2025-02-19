using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    TextMeshProUGUI goldText;

    public Image characterFrameImage;
    public List<CharacterScriptableObject> charactersInfo;

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

    public void ChangeCharacterFrameImage(Character currentCharacter)
    {
        characterFrameImage.sprite = charactersInfo[(int)currentCharacter].sprite;
        characterFrameImage.gameObject.transform.localScale = charactersInfo[(int)currentCharacter].scale;
        characterFrameImage.SetNativeSize();
    }
}
