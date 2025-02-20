using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public enum Scene
{
    Start,
    Lobby,
    Stack,
    Obstacle,
    MakeTen
}

public class ScreenFader : MonoBehaviour
{
    private static ScreenFader Instance { get; set; }

    Canvas[] canvas;
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

        sprite.color = new Color(0, 0, 0, 0);
    }

    public IEnumerator FadeOutSceneChange(Scene state)
    {
        canvas = FindObjectsOfType<Canvas>();

        // 캔버스 비활성화
        if (canvas != null)
        {
            foreach (Canvas c in canvas)
            {
                c.gameObject.SetActive(false);
            }
        }
            

        // 목표 컬러
        Color targetColor = new Color(0, 0, 0, 1);

        float t = 0f;

        while (t < 1.5f)
        {
            t += Time.deltaTime;
            float clamp = Mathf.Clamp01(t / 1);
            sprite.color = Color.Lerp(sprite.color, targetColor, clamp);

            yield return null;
        }

        SceneManager.LoadScene((int)state);
        StartCoroutine(FadeInSceneChange());
    }

    public IEnumerator FadeInSceneChange()
    {
        sprite.color = new Color(0, 0, 0, 1);

        canvas = FindObjectsOfType<Canvas>();


        // 목표 컬러
        Color targetColor = new Color(0, 0, 0, 0);

        float t = 0f;

        while (t < 1.5f)
        {
            t += Time.deltaTime;
            float clamp = Mathf.Clamp01(t / 1); // 값을 0에서 1로 제한
            sprite.color = Color.Lerp(sprite.color, targetColor, clamp);

            yield return null;
        }

        // 캔버스 활성화
        if (canvas != null)
        {
            foreach (Canvas c in canvas)
            {
                c.gameObject.SetActive(true);
            }
        }
    }
}
