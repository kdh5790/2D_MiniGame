using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDestroyZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // ������ ��Ҵٸ� �ı�
        if(collision.gameObject.name.Equals("Rubble"))
        {
            Destroy(collision.gameObject);
        }
    }
}
