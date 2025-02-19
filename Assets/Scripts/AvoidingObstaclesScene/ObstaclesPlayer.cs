using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPlayer : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rigid;
    CircleCollider2D circelCollider;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        circelCollider = GetComponent<CircleCollider2D>();
    }

    public void Dead()
    {
        sprite.color = new Color(0.3f, 0.3f, 0.3f);
        rigid.gravityScale = 1f;
        circelCollider.isTrigger = true;
    }
}
