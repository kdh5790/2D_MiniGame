using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public bool isDead = false;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private Vector2 moveVelocity;
    private Vector2 moveDirection;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (!isDead)
            Move();
    }

    void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // �̵� ������ �ƴ��� üũ �Ͽ� �ִϸ��̼� ����
        if (animator != null)
            animator.SetBool("IsMove", moveInput.magnitude == 0 ? false : true);

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
