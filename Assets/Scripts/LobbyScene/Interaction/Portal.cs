using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] runeSprites;
    private bool isActive = false;

    private void Update()
    {
        if (!isActive)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveScene();
        }
    }

    private void MoveScene()
    {
        ScreenFader fader = FindObjectOfType<ScreenFader>();

        if(fader != null)
            StartCoroutine(fader.FadeOutSceneChange(Scene.Stack));
        else
            SceneManager.LoadScene((int)Scene.Stack);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isActive = true;

            foreach (var sprite in runeSprites)
            {
                sprite.sortingOrder = -39;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = false;

            foreach (var sprite in runeSprites)
            {
                sprite.sortingOrder = -45;
            }
        }
    }
}
