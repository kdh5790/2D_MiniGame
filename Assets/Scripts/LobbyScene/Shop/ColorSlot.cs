using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color _color;
    private Image previewImage;
    private ColorManager colorManager;

    private void Start()
    {
        previewImage = FindObjectOfType<ShopUI>().transform.Find("CharacterFrame").GetComponent<Image>();
        colorManager = FindObjectOfType<ColorManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        previewImage.color = _color;
        colorManager.previewColor = _color;
    }
}
