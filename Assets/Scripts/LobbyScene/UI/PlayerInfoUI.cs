using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    TextMeshProUGUI goldText;

    public Image characterFrameImage; // ���� UI�� ĳ���� ������ �̹���
    public List<CharacterScriptableObject> charactersInfo; // �÷��̾�� ĳ���͵��� ��ũ��Ʈ������Ʈ ����Ʈ
                                                           // Character enum(����, �̸�), ��������Ʈ, �ʱ� ũ��, ���� 

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

    // ���� ĳ���ͷ� ������ �̹��� ����
    public void ChangeCharacterFrameImage(Character currentCharacter)
    {
        characterFrameImage.sprite = charactersInfo[(int)currentCharacter].sprite;
        characterFrameImage.gameObject.transform.localScale = charactersInfo[(int)currentCharacter].scale;
        characterFrameImage.SetNativeSize();
    }
}
