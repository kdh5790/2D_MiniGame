using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private GameObject dragPrefab; // �巡�� �ڽ� ������
    private GameObject instantiateSquare; // ������ �巡�� �ڽ�

    private Vector3 startPos;
    private Vector3 nowPos;
    private Vector3 deltaPos;

    float deltaX;
    float deltaY;

    void Update()
    {
        if (!MakeTen.instance.isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartDrag();
            }

            if (Input.GetMouseButton(0))
            {
                UpdateDragArea();
            }

            if (Input.GetMouseButtonUp(0))
            {
                // ���� ���õ�(�巡�� ������ ����) ���ڵ��� ���� 10�̶��
                if (MakeTen.instance.sum == 10)
                {
                    foreach (GameObject go in MakeTen.instance.selectedNumber.ToList())
                    {
                        // ���� �߰�, ����Ʈ���� ���� �� ������Ʈ �ı�
                        MakeTen.instance.score++;
                        MakeTen.instance.selectedNumber.Remove(go);
                        Destroy(go);
                    }
                }

                // �巡�׹ڽ� �ı�
                Destroy(instantiateSquare);
                MakeTen.instance.sum = 0;
            }
        }
        else
        {
            Destroy(instantiateSquare);

        }
    }

    private void StartDrag()
    {
        // ���콺 Ŭ�� ���� ��ġ�� ���� ��ǥ�� ��ȯ
        startPos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));

        // �巡�׹ڽ� ����
        instantiateSquare = Instantiate(dragPrefab, Vector3.zero, Quaternion.identity);
    }

    private void UpdateDragArea()
    {
        // ���� ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        nowPos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));

        // X�� ������ �巡�� �Ÿ� ���
        deltaX = Mathf.Abs(nowPos.x - startPos.x);

        // Y�� ������ �巡�� �Ÿ� ���
        deltaY = Mathf.Abs(nowPos.y - startPos.y);

        // �巡�� ������ �߽��� ���
        deltaPos = startPos + (nowPos - startPos) / 2;

        // ������Ʈ�� ��ġ�� �巡�� ������ �߽������� ����
        instantiateSquare.transform.position = deltaPos;

        // ������Ʈ�� ũ�⸦ �巡�� ������ �°� ����
        instantiateSquare.transform.localScale = new Vector3(deltaX, deltaY, 0);
    }
}
