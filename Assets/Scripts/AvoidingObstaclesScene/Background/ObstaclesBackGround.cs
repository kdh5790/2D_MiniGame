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
        // 장애물 생성
        StartCreateObstacle();

        foreach (GameObject go in backgroundList)
        {
            // 배경화면 초기 위치 추가
            initBackgroundPostionList.Add(go.transform.localPosition);
        }
    }

    void Update()
    {
        // 아래로 일정한 속도로 이동
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    void StartCreateObstacle()
    {
        // 첫 생성이라면 1 아니라면 0 부터 시작해 장애물 생성
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

    // 5초 마다 속도 증가 코루틴
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
