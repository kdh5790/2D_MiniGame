using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneBackground : MonoBehaviour
{
    public List<GameObject> backGroundCloud = new List<GameObject>(); // ��� ����

    public float speed; // ���� �̵� �ӵ�

    void FixedUpdate()
    {
        // �������� deltaTime * speed ��ŭ �̵���Ŵ
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
