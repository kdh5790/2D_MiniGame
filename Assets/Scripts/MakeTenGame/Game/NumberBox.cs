using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBox : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TriggerEnter");
        sprite.color = new Color(1, 0.5f, 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("TriggerExit");
        sprite.color = new Color(1, 1, 1);
    }
}
