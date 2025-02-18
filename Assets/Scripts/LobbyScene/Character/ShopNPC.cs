using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    private bool isActive = false;
    private ShopUI shopUI;

    private void Update()
    {
        shopUI = FindObjectOfType<ShopUI>(true);

        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            shopUI.OpenShopUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isActive = false;

            if(shopUI.gameObject.activeSelf)
            {
                shopUI.CloseShopUI();
            }
        }
    }
}
