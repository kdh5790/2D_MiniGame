using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private Vector2 moveVelocity;
    private Vector2 moveDirection;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
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

        if (animator != null)
        {
            if (moveInput.magnitude == 0)
                animator.SetBool("IsMove", false);
            else
                animator.SetBool("IsMove", true);
        }

        moveVelocity = moveInput.normalized * moveSpeed; // �̵� �ӵ� ���ϱ�
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime); // �̵�
        moveDirection = moveVelocity.normalized; // �̵����� ���� ���ϱ�

        if (animator != null)
            FlipSprite(moveDirection.x); // �̵� ���⿡ ���� ĳ���� ȸ��
    }

    void FlipSprite(float directionX)
    {
        if (directionX < 0) // �������� �̵� ��
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (directionX > 0) // ���������� �̵� ��
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
