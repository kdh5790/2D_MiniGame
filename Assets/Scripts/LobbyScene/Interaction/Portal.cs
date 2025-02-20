using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private Scene targetScene; // �̵��� Scene
    [SerializeField] private SpriteRenderer[] runeSprites; // �鹮�� ��������Ʈ
    private bool isActive = false;

    private void Update()
    {
        if (!isActive)
            return;

        // Ȱ��ȭ ���¿��� �����̽� Ű �Է� �� Scene �̵�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveScene();
        }
    }

    // Scene �̵�
    private void MoveScene()
    {
        ScreenFader fader = FindObjectOfType<ScreenFader>();

        if(fader != null)
            StartCoroutine(fader.FadeOutSceneChange(targetScene));
        else
            SceneManager.LoadScene((int)targetScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // �÷��̾ Ʈ���ſ� ���Դٸ� �鹮���� ���ÿ����� ��Ż ���� ����
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
            // �÷��̾ Ʈ���ſ��� ���������ٸ� �鹮���� ���ÿ����� ��Ż �Ʒ��� ����
            isActive = false;

            foreach (var sprite in runeSprites)
            {
                sprite.sortingOrder = -45;
            }
        }
    }
}
