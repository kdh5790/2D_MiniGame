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
        StartCreateObstacle();

        foreach (GameObject go in backgroundList)
        {
            initBackgroundPostionList.Add(go.transform.localPosition);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    void StartCreateObstacle()
    {
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

    public IEnumerator SpeedUpCoroutine()
    {
        StopAllCoroutines();

        PlayerController player = FindObjectOfType<PlayerController>();

        player.GetComponent<ObstaclesPlayer>().Restart();

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
