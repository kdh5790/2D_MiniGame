using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneBackground : MonoBehaviour
{
    public List<GameObject> backGroundCloud = new List<GameObject>(); // 배경 구름

    public float speed; // 구름 이동 속도

    void FixedUpdate()
    {
        // 왼쪽으로 deltaTime * speed 만큼 이동시킴
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
