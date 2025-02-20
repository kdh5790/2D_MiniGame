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
        // Ʈ���ſ� ���� ������Ʈ�� �±װ� Player��� �ƿ����� Ȱ��ȭ
        if(collision.CompareTag("Player"))
        {
            sprite.material.SetFloat("_OutlineEnabled", 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ʈ���ſ��� ���� ������Ʈ�� �±װ� Player��� �ƿ����� ��Ȱ��ȭ
            sprite.material.SetFloat("_OutlineEnabled", 0);
        }
    }
}
