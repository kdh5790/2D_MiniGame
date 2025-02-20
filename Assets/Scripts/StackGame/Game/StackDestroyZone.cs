using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDestroyZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // ÆÄÆíÀÌ ´ê¾Ò´Ù¸é ÆÄ±«
        if(collision.gameObject.name.Equals("Rubble"))
        {
            Destroy(collision.gameObject);
        }
    }
}
