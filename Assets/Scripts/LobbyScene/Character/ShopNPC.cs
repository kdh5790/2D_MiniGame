using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : NPC
{
    private ShopUI shopUI;

    private void Update()
    {
        shopUI = FindObjectOfType<ShopUI>(true);

        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            shopUI.OpenShopUI();
        }
    }
}
