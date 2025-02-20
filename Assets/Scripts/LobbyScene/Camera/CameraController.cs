using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public PlayerController player;

    float maxX = 7.1f; // ������ X��
    float minX = -2.1f;
    float maxY = 2f; // ������ Y��
    float minY = -3f;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        // ī�޶� �÷��̾ ���� �̵��ϵ��� ����
        Vector3 direction = player.transform.position - transform.position;
        Vector3 moveVector = new Vector3(direction.x * cameraSpeed * Time.deltaTime, direction.y * cameraSpeed * Time.deltaTime, 0.0f);
        transform.Translate(moveVector);

        // ī�޶� ������ġ�� ��������� ����
        Vector3 cameraPostion = transform.position;

        if (cameraPostion.x > maxX) cameraPostion.x = maxX;
        if (cameraPostion.x < minX) cameraPostion.x = minX;
        if (cameraPostion.y > maxY) cameraPostion.y = maxY;
        if (cameraPostion.y < minY) cameraPostion.y = minY;

        transform.position = cameraPostion;
    }
}
