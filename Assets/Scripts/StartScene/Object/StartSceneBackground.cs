using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneBackground : MonoBehaviour
{
    public List<GameObject> backGroundCloud = new List<GameObject>(); // 배경 구름

    public float speed; // 구름 이동 속도

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
