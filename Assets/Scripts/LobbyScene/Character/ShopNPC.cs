using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    private bool isActive = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            FindObjectOfType<ShopUI>(true).OpenShopUI();
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
        }
    }
}
