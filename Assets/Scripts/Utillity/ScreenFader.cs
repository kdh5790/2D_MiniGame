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
        // 현재 Scene에 존재하는 캔버스들 찾기
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

        // 시간
        float t = 0f;

        // 1.5 : 페이드 아웃 할 시간
        while (t < 1.5f)
        {
            t += Time.deltaTime;
            float clamp = Mathf.Clamp01(t / 1); // 값을 0에서 1로 제한
            sprite.color = Color.Lerp(sprite.color, targetColor, clamp); // 현재 스프라이트 컬러를 tagetColor가 될 때 까지 clamp변수만큼 증가

            yield return null;
        }

        // Scene 변경
        SceneManager.LoadScene((int)state);

        // Scene 변경 이후 FadeIn 코루틴 시작
        StartCoroutine(FadeInSceneChange());
    }

    public IEnumerator FadeInSceneChange()
    {
        // 스프라이트 검은색으로 변경
        sprite.color = new Color(0, 0, 0, 1);

        // 현재 Scene에 존재하는 캔버스들 찾기
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

        // FadeIn 완료 후 모든 캔버스 활성화
        if (canvas != null)
        {
            foreach (Canvas c in canvas)
            {
                c.gameObject.SetActive(true);
            }
        }
    }
}
