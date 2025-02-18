using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    Button closeButton;

    private void Start()
    {
        closeButton = transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(CloseShopUI);
    }

    public void OpenShopUI()
    {
        gameObject.SetActive(true);
    }

    public void CloseShopUI()
    {
        gameObject.SetActive(false);
    }
}
