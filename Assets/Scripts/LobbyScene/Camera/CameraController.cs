using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public PlayerController player;

    float maxX = 7.1f; // 제한할 X값
    float minX = -2.1f;
    float maxY = 2f; // 제한할 Y값
    float minY = -3f;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        // 카메라가 플레이어를 따라 이동하도록 설정
        Vector3 direction = player.transform.position - transform.position;
        Vector3 moveVector = new Vector3(direction.x * cameraSpeed * Time.deltaTime, direction.y * cameraSpeed * Time.deltaTime, 0.0f);
        transform.Translate(moveVector);

        // 카메라가 일정위치를 못벗어나도록 제한
        Vector3 cameraPostion = transform.position;

        if (cameraPostion.x > maxX) cameraPostion.x = maxX;
        if (cameraPostion.x < minX) cameraPostion.x = minX;
        if (cameraPostion.y > maxY) cameraPostion.y = maxY;
        if (cameraPostion.y < minY) cameraPostion.y = minY;

        transform.position = cameraPostion;
    }
}
