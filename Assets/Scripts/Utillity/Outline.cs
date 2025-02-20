using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

        sprite.material.SetFloat("_OutlineEnabled", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 트리거에 닿은 오브젝트의 태그가 Player라면 아웃라인 활성화
        if(collision.CompareTag("Player"))
        {
            sprite.material.SetFloat("_OutlineEnabled", 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 트리거에서 나간 오브젝트의 태그가 Player라면 아웃라인 비활성화
            sprite.material.SetFloat("_OutlineEnabled", 0);
        }
    }
}
