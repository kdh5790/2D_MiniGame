using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneBackground : MonoBehaviour
{
    public List<GameObject> backGroundCloud = new List<GameObject>(); // ��� ����

    public float speed; // ���� �̵� �ӵ�

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
