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
        // ��ֹ� ������Ʈ ���� �� ť�� �־��ֱ�
        for (int i = 0; i < poolCount; i++)
        {
            GameObject go = Instantiate(obtaclePrefab, transform);
            go.SetActive(false);
            obstaclePool.Enqueue(go);
        }
    }

    public void CreateObtacle()
    {
        // ���� ������ ��ֹ��� ��Ȱ�� �� �ٽ� ť�� �־���
        foreach (var obj in obtacleList)
        { 
            obj.SetActive(false);
            obstaclePool.Enqueue(obj);
        }


        // ť���� ��ֹ��� ������ ��ġ ���� ���� �� Ȱ��ȭ�ϰ� ����Ʈ�� �־���
        for (int i = 0; i < 5; i++)
        {
            GameObject go = obstaclePool.Dequeue();
            go.transform.localPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1.3f, 1.3f));
            go.SetActive(true);
            obtacleList.Add(go);
        }
    }
}
