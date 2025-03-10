using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public Color previewColor = Color.white; // 미리보기 색상

    Image previewcharacterFrame;
    Button applyColorButton; // 적용 버튼
    Button restoreButton; // 되돌리기 버튼

    void Start()
    {
        applyColorButton = transform.Find("ApplyColorButton").GetComponent<Button>();
        restoreButton = transform.Find("RestoreButton").GetComponent<Button>();
        previewcharacterFrame = transform.Find("CharacterFrame").GetComponent<Image>();

        applyColorButton.onClick.AddListener(OnClickApplyButton);
        restoreButton.onClick.AddListener(OnClickRestoreButton);
    }

    void OnClickApplyButton()
    {
        FindObjectOfType<PlayerController>().GetComponentInChildren<SpriteRenderer>().color = previewColor;
        FindObjectOfType<PlayerInfoUI>().characterFrameImage.color = previewColor;
    }

    void OnClickRestoreButton()
    {
        previewColor = Color.white;
        previewcharacterFrame.color = previewColor;
    }
}
