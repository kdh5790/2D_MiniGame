using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;


    private Animator anim;
    private Rigidbody2D rigidBody;

    private Vector2 moveVelocity;
    private Vector2 moveDirection;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
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

        // �̵� ���̶�� �ִϸ��̼� ����
        if (moveInput.magnitude != 0)
            anim.SetBool("IsMove", true);
        else
            anim.SetBool("IsMove", false);

        moveVelocity = moveInput.normalized * moveSpeed; // �̵� �ӵ� ���ϱ�
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime); // �̵�
        moveDirection = moveVelocity.normalized; // �̵����� ���� ���ϱ�

        FlipSprite(moveDirection.x); // �̵� ���⿡ ���� ĳ���� ȸ��
    }

    void FlipSprite(float directionX)
    {
        if(directionX < 0) // �������� �̵� ��
        {
            this.gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if(directionX > 0) // ���������� �̵� ��
        {
            this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
