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
        // ���� Scene�� �����ϴ� ĵ������ ã��
        canvas = FindObjectsOfType<Canvas>();

        // ĵ���� ��Ȱ��ȭ
        if (canvas != null)
        {
            foreach (Canvas c in canvas)
            {
                c.gameObject.SetActive(false);
            }
        }
            

        // ��ǥ �÷�
        Color targetColor = new Color(0, 0, 0, 1);

        // �ð�
        float t = 0f;

        // 1.5 : ���̵� �ƿ� �� �ð�
        while (t < 1.5f)
        {
            t += Time.deltaTime;
            float clamp = Mathf.Clamp01(t / 1); // ���� 0���� 1�� ����
            sprite.color = Color.Lerp(sprite.color, targetColor, clamp); // ���� ��������Ʈ �÷��� tagetColor�� �� �� ���� clamp������ŭ ����

            yield return null;
        }

        // Scene ����
        SceneManager.LoadScene((int)state);

        // Scene ���� ���� FadeIn �ڷ�ƾ ����
        StartCoroutine(FadeInSceneChange());
    }

    public IEnumerator FadeInSceneChange()
    {
        // ��������Ʈ ���������� ����
        sprite.color = new Color(0, 0, 0, 1);

        // ���� Scene�� �����ϴ� ĵ������ ã��
        canvas = FindObjectsOfType<Canvas>();


        // ��ǥ �÷�
        Color targetColor = new Color(0, 0, 0, 0);

        float t = 0f;

        while (t < 1.5f)
        {
            t += Time.deltaTime;
            float clamp = Mathf.Clamp01(t / 1); // ���� 0���� 1�� ����
            sprite.color = Color.Lerp(sprite.color, targetColor, clamp);

            yield return null;
        }

        // FadeIn �Ϸ� �� ��� ĵ���� Ȱ��ȭ
        if (canvas != null)
        {
            foreach (Canvas c in canvas)
            {
                c.gameObject.SetActive(true);
            }
        }
    }
}
