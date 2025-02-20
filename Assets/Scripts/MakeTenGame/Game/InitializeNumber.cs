using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeNumber : MonoBehaviour
{
    [SerializeField] private List<GameObject> numberPrefabs = new List<GameObject>();

    public List<GameObject> inGameNumbers = new List<GameObject>();

    float posX = -5.5f;
    float posY = 4.4f;

    public void InitializePannel()
    {
        // 첫 블록을 생성할 위치
        Vector2 firstPos = new Vector2(posX, posY);

        // 12 x 16 크기로 블록 생성
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                // 랜덤한 숫자로 블록 생성, 부모 지정
                GameObject go = Instantiate(numberPrefabs[Random.Range(0, 9)], transform);

                // 위치 설정
                go.transform.localPosition = new Vector2(posX, posY);

                // 현재 생성된 블록 리스트에 추가
                inGameNumbers.Add(go);

                // X값 증가
                posX += 0.7f;
            }

            // 16개의 블록을 생성 한 후 X값 초기화 후 Y값 감소
            posX = firstPos.x;
            posY -= 0.8f;
        }
    }
}
