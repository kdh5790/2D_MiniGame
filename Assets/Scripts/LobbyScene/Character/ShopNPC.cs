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

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        if (collision.CompareTag("Player"))
        {
            // 트리거를 빠져나갔다면 상점 닫기
            shopUI.CloseShopUI();
        }
    }
}
