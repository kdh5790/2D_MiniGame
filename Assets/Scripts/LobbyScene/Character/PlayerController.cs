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

        moveVelocity = moveInput.normalized * moveSpeed; // 이동 속도 구하기
        rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime); // 이동
        moveDirection = moveVelocity.normalized; // 이동중인 방향 구하기

        FlipSprite(moveDirection.x); // 이동 방향에 따라 캐릭터 회전
    }

    void FlipSprite(float directionX)
    {
        if(directionX < 0) // 왼쪽으로 이동 중
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(directionX > 0) // 오른쪽으로 이동 중
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
