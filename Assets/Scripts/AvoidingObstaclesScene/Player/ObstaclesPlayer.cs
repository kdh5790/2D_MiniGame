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
        // 사망했다면 색 변경, 중력을 추가해 아래로 떨어지게함, isTrigger를 활성화 해 주변 콜라이더에 부딪히지 않게 함
        sprite.color = new Color(0.3f, 0.3f, 0.3f);
        rigid.gravityScale = 1f;
        circelCollider.isTrigger = true;

        // 생존한 시간 저장
        float time = FindObjectOfType<ObstacleGameUI>(true).time;

        // 백그라운드 속도 변경, ScoreUI 활성화 후 점수 세팅
        FindObjectOfType<ObstaclesBackGround>().speed = 0f;
        FindObjectOfType<ObstacleGameUI>(true).gameObject.SetActive(false);
        FindObjectOfType<ObstacleScoreUI>(true).gameObject.SetActive(true);
        FindObjectOfType<ObstacleScoreUI>().SetScore(time);
    }
}
