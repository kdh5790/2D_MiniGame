using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rigidBody;

    private Vector2 moveVelocity;
    private Vector2 moveDirection;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput.normalized * moveSpeed; // �̵� �ӵ� ���ϱ�
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime); // �̵�
        moveDirection = moveVelocity.normalized; // �̵����� ���� ���ϱ�

        FlipSprite(moveDirection.x); // �̵� ���⿡ ���� ĳ���� ȸ��
    }

    void FlipSprite(float directionX)
    {
        if(directionX < 0) // �������� �̵� ��
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(directionX > 0) // ���������� �̵� ��
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
