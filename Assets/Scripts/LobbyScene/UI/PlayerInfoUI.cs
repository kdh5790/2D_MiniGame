using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpriteInfoWrapper
{
    public Sprite sprite;
    public Vector2 scale;
}

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    TextMeshProUGUI goldText;
    Image characterFrameImage;

    public List<SpriteInfoWrapper> wrappers;

    private void Start()
    {
        goldText = GetComponentInChildren<TextMeshProUGUI>();
        characterFrameImage = transform.Find("SpriteFrame").Find("PlayerSprite").GetComponent<Image>();

        UpdateGoldText();
        ChangeCharacterFrameImage(Character.Knight);
    }

    public void UpdateGoldText()
    {
        goldText.text = GoldManager.instance.PlayerGold.ToString();
    }

    public void ChangeCharacterFrameImage(Character currentCharacter)
    {
        characterFrameImage.sprite = wrappers[(int)currentCharacter].sprite;
        characterFrameImage.gameObject.transform.localScale = wrappers[(int)currentCharacter].scale;
        characterFrameImage.SetNativeSize();
    }
}
