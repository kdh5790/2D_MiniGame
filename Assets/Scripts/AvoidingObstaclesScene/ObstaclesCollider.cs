using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCollider : MonoBehaviour
{
    private readonly float fixedValue = 10.24f; // ��׶��� ������Ʈ ���� �Ÿ�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        // �ε��� ������Ʈ �±װ� ��׶�����
        if (collision.gameObject.CompareTag("BackGround"))
        {
            // �θ� ������Ʈ���� Background Ŭ���� ��������
            ObstaclesBackGround bg = collision.gameObject.GetComponentInParent<ObstaclesBackGround>();

            if (bg == null) { Debug.Log("Background�� ã�� ���߽��ϴ�."); return; }


            float distance = 0f; // �Ÿ��� ������ ����
            Vector3 postion = new Vector3(); // ��ġ�� ������ ����

            foreach (var image in bg.backgroundList)
            {
                // ���� �� �Ÿ� ���ϱ�
                if (Vector3.Distance(collision.gameObject.transform.position, image.transform.position) > distance)
                {
                    distance = Vector3.Distance(collision.gameObject.transform.position, image.transform.position);
                    postion = new Vector3(0, image.transform.position.y + fixedValue, 0);
                }
            }

            // ���� �հŸ��� ������Ʈ�� (x�� + ������, 0, 0) ���� ��ġ ����
            collision.gameObject.transform.position = postion;
            collision.GetComponent<ObstacleCreator>().CreateObtacle();
        }
    }
}
