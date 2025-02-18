using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public void OpenShopUI()
    {
        gameObject.SetActive(true);
    }

    public void CloseShopUI()
    {
        gameObject.SetActive(false);
    }
}
