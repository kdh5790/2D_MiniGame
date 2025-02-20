using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public PlayerController player;

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
    }
}
