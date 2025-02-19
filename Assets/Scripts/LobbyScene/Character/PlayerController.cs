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

        moveVelocity = moveInput.normalized * moveSpeed; // 이동 속도 구하기
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime); // 이동
        moveDirection = moveVelocity.normalized; // 이동중인 방향 구하기

        if (animator != null)
            FlipSprite(moveDirection.x); // 이동 방향에 따라 캐릭터 회전
    }

    void FlipSprite(float directionX)
    {
        if (directionX < 0) // 왼쪽으로 이동 중
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (directionX > 0) // 오른쪽으로 이동 중
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
