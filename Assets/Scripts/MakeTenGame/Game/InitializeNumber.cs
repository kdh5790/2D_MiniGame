using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeNumber : MonoBehaviour
{
    [SerializeField] private List<GameObject> numberPrefabs = new List<GameObject>();

    public List<GameObject> inGameNumbers = new List<GameObject>();

    float posX = -5.5f;
    float posY = 4.4f;

    public void InitializePannel()
    {
        // ù ����� ������ ��ġ
        Vector2 firstPos = new Vector2(posX, posY);

        // 12 x 16 ũ��� ��� ����
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                // ������ ���ڷ� ��� ����, �θ� ����
                GameObject go = Instantiate(numberPrefabs[Random.Range(0, 9)], transform);

                // ��ġ ����
                go.transform.localPosition = new Vector2(posX, posY);

                // ���� ������ ��� ����Ʈ�� �߰�
                inGameNumbers.Add(go);

                // X�� ����
                posX += 0.7f;
            }

            // 16���� ����� ���� �� �� X�� �ʱ�ȭ �� Y�� ����
            posX = firstPos.x;
            posY -= 0.8f;
        }
    }
}
