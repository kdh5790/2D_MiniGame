using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private GameObject dragPrefab; // 드래그 박스 프리팹
    private GameObject instantiateSquare; // 생성한 드래그 박스

    private Vector3 startPos;
    private Vector3 nowPos;
    private Vector3 deltaPos;

    float deltaX;
    float deltaY;

    void Update()
    {
        if (!MakeTen.instance.isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartDrag();
            }

            if (Input.GetMouseButton(0))
            {
                UpdateDragArea();
            }

            if (Input.GetMouseButtonUp(0))
            {
                // 현재 선택된(드래그 영역에 들어온) 숫자들의 합이 10이라면
                if (MakeTen.instance.sum == 10)
                {
                    foreach (GameObject go in MakeTen.instance.selectedNumber.ToList())
                    {
                        // 점수 추가, 리스트에서 삭제 후 오브젝트 파괴
                        MakeTen.instance.score++;
                        MakeTen.instance.selectedNumber.Remove(go);
                        Destroy(go);
                    }
                }

                // 드래그박스 파괴
                Destroy(instantiateSquare);
                MakeTen.instance.sum = 0;
            }
        }
        else
        {
            Destroy(instantiateSquare);

        }
    }

    private void StartDrag()
    {
        // 마우스 클릭 시작 위치를 월드 좌표로 변환
        startPos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));

        // 드래그박스 생성
        instantiateSquare = Instantiate(dragPrefab, Vector3.zero, Quaternion.identity);
    }

    private void UpdateDragArea()
    {
        // 현재 마우스 위치를 월드 좌표로 변환
        nowPos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));

        // X축 방향의 드래그 거리 계산
        deltaX = Mathf.Abs(nowPos.x - startPos.x);

        // Y축 방향의 드래그 거리 계산
        deltaY = Mathf.Abs(nowPos.y - startPos.y);

        // 드래그 영역의 중심점 계산
        deltaPos = startPos + (nowPos - startPos) / 2;

        // 오브젝트의 위치를 드래그 영역의 중심점으로 설정
        instantiateSquare.transform.position = deltaPos;

        // 오브젝트의 크기를 드래그 영역에 맞게 조정
        instantiateSquare.transform.localScale = new Vector3(deltaX, deltaY, 0);
    }
}
