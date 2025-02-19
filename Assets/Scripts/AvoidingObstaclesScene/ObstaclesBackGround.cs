using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBackGround : MonoBehaviour
{
    public List<GameObject> backgroundList;
    public float speed = 2f;
    public bool isFirst = true;

    private void Start()
    {
        StartCreateObacle();
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    void StartCreateObacle()
    {
        for (int i = isFirst ? 1 : 0; i < backgroundList.Count; i++)
        {
            Debug.Log(i);
            backgroundList[i].GetComponent<ObstacleCreator>().CreateObtacle();
        }
        isFirst = false;
    }
}
