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
        sprite.color = new Color(1, 0.5f, 0.5f);
        MakeTen.instance.selectedNumber.Add(this.gameObject);
        MakeTen.instance.sum += num;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.color = new Color(1, 1, 1);
        MakeTen.instance.selectedNumber.Remove(this.gameObject);
        MakeTen.instance.sum -= num;
    }
}
