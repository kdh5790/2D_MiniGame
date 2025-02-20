using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // 플레이어가 닿았다면 사망판정
            collision.GetComponent<PlayerController>().isDead = true;
            collision.GetComponent<ObstaclesPlayer>().Dead();
        }
    }
}
