using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public enum Scene
{
    Start,
    Lobby,
    Stack,
    Obstacle
}

public class ScreenFader : MonoBehaviour
{
    private static ScreenFader Instance { get; set; }

    Canvas canvas;
    SpriteRenderer sprite;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        sprite.color = new UnityEngine.Color(0, 0, 0, 0);
    }

    public IEnumerator FadeOutSceneChange(Scene state)
    {
        canvas = FindObjectOfType<Canvas>();

        // ĵ���� ��Ȱ��ȭ
        if (canvas != null)
            canvas.gameObject.SetActive(false);

        // ��ǥ �÷�
        UnityEngine.Color target = new UnityEngine.Color(0, 0, 0, 1);

        float t = 0f; // 
        float speed = 0.4f; // ���̵� �ƿ� �ӵ�

        while (t < 1)
        {
            t += Time.deltaTime * speed;
            sprite.color = UnityEngine.Color.Lerp(sprite.color, target, t);

            yield return null;
        }

        SceneManager.LoadScene((int)state);
        StartCoroutine(FadeInSceneChange());
    }

    public IEnumerator FadeInSceneChange()
    {
        canvas = FindObjectOfType<Canvas>();


        // ��ǥ �÷�
        UnityEngine.Color target = new UnityEngine.Color(0, 0, 0, 0);

        float t = 0f; // 
        float speed = 0.1f; // ���̵� �ƿ� �ӵ�

        while (t < 1)
        {
            t += Time.deltaTime * speed;
            t = Mathf.Clamp01(t / 1); // ���� 0���� 1�� ����
            sprite.color = UnityEngine.Color.Lerp(sprite.color, target, t);

            yield return null;
        }

        // ĵ���� Ȱ��ȭ
        if (canvas != null)
            canvas.gameObject.SetActive(true);

        StopAllCoroutines();
    }
}
