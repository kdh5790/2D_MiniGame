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

        // 이동 중인지 아닌지 체크 하여 애니메이션 변경
        if (animator != null)
            animator.SetBool("IsMove", moveInput.magnitude == 0 ? false : true);

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
