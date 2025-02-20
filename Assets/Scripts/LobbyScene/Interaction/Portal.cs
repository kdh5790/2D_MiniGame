using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private Scene targetScene; // 이동할 Scene
    [SerializeField] private SpriteRenderer[] runeSprites; // 룬문양 스프라이트
    private bool isActive = false;

    private void Update()
    {
        if (!isActive)
            return;

        // 활성화 상태에서 스페이스 키 입력 시 Scene 이동
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveScene();
        }
    }

    // Scene 이동
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
            // 플레이어가 트리거에 들어왔다면 룬문양의 솔팅오더를 포탈 위로 변경
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
            // 플레이어가 트리거에서 빠져나갔다면 룬문양의 솔팅오더를 포탈 아래로 변경
            isActive = false;

            foreach (var sprite in runeSprites)
            {
                sprite.sortingOrder = -45;
            }
        }
    }
}
