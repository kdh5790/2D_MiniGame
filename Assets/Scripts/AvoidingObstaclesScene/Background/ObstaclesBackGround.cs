using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesBackGround : MonoBehaviour
{
    public List<GameObject> backgroundList;
    public float speed = 0f;
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
        PlayerController player = FindObjectOfType<PlayerController>();

        speed = 2f;

        while (!player.isDead)
        {
            IncreaseSpeed(0.2f);
            yield return new WaitForSeconds(5.0f);
        }
    }

    private void IncreaseSpeed(float increaseSpeed)
    {
        speed += increaseSpeed;
    }
}
