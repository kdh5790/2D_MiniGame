using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1, 1.3
public class ObstacleCreator : MonoBehaviour
{
    public GameObject obtaclePrefab;
    public List<GameObject> obtacleList = new List<GameObject>();

    public void CreateObtacle()
    {
        foreach(var obj in obtacleList)
            Destroy(obj);

        for (int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(obtaclePrefab, transform);
            go.transform.localPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1.3f, 1.3f));
            obtacleList.Add(go);
        }
    }
}
