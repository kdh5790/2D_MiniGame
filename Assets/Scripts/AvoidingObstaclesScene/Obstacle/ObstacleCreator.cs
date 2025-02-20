using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1, 1.3
public class ObstacleCreator : MonoBehaviour
{
    public GameObject obtaclePrefab;
    public List<GameObject> obtacleList = new List<GameObject>();
    
    private int poolCount = 5;
    private Queue<GameObject> obstaclePool = new Queue<GameObject>();

    private void Awake()
    {
        // 장애물 오브젝트 생성 및 큐에 넣어주기
        for (int i = 0; i < poolCount; i++)
        {
            GameObject go = Instantiate(obtaclePrefab, transform);
            go.SetActive(false);
            obstaclePool.Enqueue(go);
        }
    }

    public void CreateObtacle()
    {
        // 현재 생성된 장애물을 비활성 후 다시 큐에 넣어줌
        foreach (var obj in obtacleList)
        { 
            obj.SetActive(false);
            obstaclePool.Enqueue(obj);
        }


        // 큐에서 장애물을 꺼내와 위치 랜덤 설정 후 활성화하고 리스트에 넣어줌
        for (int i = 0; i < 5; i++)
        {
            GameObject go = obstaclePool.Dequeue();
            go.transform.localPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1.3f, 1.3f));
            go.SetActive(true);
            obtacleList.Add(go);
        }
    }
}
