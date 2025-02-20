using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBox : MonoBehaviour
{
    private SpriteRenderer sprite;
    public int num;

    private void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 드래그 박스 안에 들어왔다면 색변경 및 리스트에 추가, num만큼 sum 추가
        sprite.color = new Color(1, 0.5f, 0.5f);
        MakeTen.instance.selectedNumber.Add(this.gameObject);
        MakeTen.instance.sum += num;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 드래그 박스에서 벗어났다면 리스트 삭제, sum 감소, 원래 색으로 변경
        sprite.color = new Color(1, 1, 1);
        MakeTen.instance.selectedNumber.Remove(this.gameObject);
        MakeTen.instance.sum -= num;
    }
}
