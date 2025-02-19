using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBackGround : MonoBehaviour
{
    public List<GameObject> backgroundList;
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
