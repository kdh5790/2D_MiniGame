using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private GameObject dragSquare;
    private GameObject square;

    private Vector3 startPos;
    private Vector3 nowPos;
    private Vector3 deltaPos;

    float deltaX;
    float deltaY;

    public bool mouseActive; 

    void Start()
    {
        mouseActive = true;
    }

    void Update()
    {
        if (mouseActive == true)
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
                Destroy(square);
            }
        }
        else
        {
            Destroy(square);
        }
    }

    private void StartDrag()
    {
        // 마우스 클릭 시작 위치를 월드 좌표로 변환
        startPos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));

        // 드래그 중인 영역을 나타낼 오브젝트 생성
        square = Instantiate(dragSquare, new Vector3(0, 0, 0), Quaternion.identity);
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
        square.transform.position = deltaPos;

        // 오브젝트의 크기를 드래그 영역에 맞게 조정
        square.transform.localScale = new Vector3(deltaX, deltaY, 0);
    }
}
