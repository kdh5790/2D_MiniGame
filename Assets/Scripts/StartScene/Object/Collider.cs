using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    private readonly float fixedValue = 17.856f; // ��׶��� ������Ʈ ���� �Ÿ�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        // �ε��� ������Ʈ �±װ� ��׶�����
        if (collision.gameObject.CompareTag("BackGround"))
        {
            // �θ� ������Ʈ���� Background Ŭ���� ��������
            Background parent = collision.gameObject.GetComponentInParent<Background>();

            if (parent == null) { Debug.Log("Background�� ã�� ���߽��ϴ�."); return; }


            float distance = 0f; // �Ÿ��� ������ ����
            Vector3 postion = new Vector3(); // ��ġ�� ������ ����

            foreach(var image in parent.backGroundCloud)
            {
                // ���� �� �Ÿ� ���ϱ�
                if (Vector3.Distance(collision.gameObject.transform.position, image.transform.position) > distance)
                {
                    distance = Vector3.Distance(collision.gameObject.transform.position, image.transform.position);
                    postion = new Vector3(image.transform.position.x + fixedValue, 0, 0);
                }
            }

            // ���� �հŸ��� ������Ʈ�� (x�� + ������, 0, 0) ���� ��ġ ����
            collision.gameObject.transform.position = postion;
        }
    }
}
