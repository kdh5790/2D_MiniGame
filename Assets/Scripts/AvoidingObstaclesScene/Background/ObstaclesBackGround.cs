using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesBackGround : MonoBehaviour
{
    public List<GameObject> backgroundList;
    public List<Vector3> initBackgroundPostionList;
    public float speed = 0f;
    public bool isFirst = true;

    private void Start()
    {
        // ��ֹ� ����
        StartCreateObstacle();

        foreach (GameObject go in backgroundList)
        {
            // ���ȭ�� �ʱ� ��ġ �߰�
            initBackgroundPostionList.Add(go.transform.localPosition);
        }
    }

    void Update()
    {
        // �Ʒ��� ������ �ӵ��� �̵�
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    void StartCreateObstacle()
    {
        // ù �����̶�� 1 �ƴ϶�� 0 ���� ������ ��ֹ� ����
        for (int i = isFirst ? 1 : 0; i < backgroundList.Count; i++)
        {
            backgroundList[i].GetComponent<ObstacleCreator>().CreateObtacle();
        }
        isFirst = false;
    }

    public void StartSpeedUpCorountine()
    {
        StartCoroutine(SpeedUpCoroutine());
    }

    // 5�� ���� �ӵ� ���� �ڷ�ƾ
    public IEnumerator SpeedUpCoroutine()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        speed = 2f;

        while (!player.isDead)
        {
            yield return new WaitForSeconds(5.0f);
            IncreaseSpeed(0.2f);
        }
    }

    private void IncreaseSpeed(float increaseSpeed)
    {
        speed += increaseSpeed;
    }
}
