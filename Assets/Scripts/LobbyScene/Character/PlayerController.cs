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

        // 이동 중이라면 애니메이션 변경
        if (moveInput.magnitude != 0)
            anim.SetBool("IsMove", true);
        else
            anim.SetBool("IsMove", false);

        moveVelocity = moveInput.normalized * moveSpeed; // 이동 속도 구하기
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime); // 이동
        moveDirection = moveVelocity.normalized; // 이동중인 방향 구하기

        FlipSprite(moveDirection.x); // 이동 방향에 따라 캐릭터 회전
    }

    void FlipSprite(float directionX)
    {
        if(directionX < 0) // 왼쪽으로 이동 중
        {
            this.gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if(directionX > 0) // 오른쪽으로 이동 중
        {
            this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
