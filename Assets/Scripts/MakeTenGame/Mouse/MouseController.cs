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
        // ���콺 Ŭ�� ���� ��ġ�� ���� ��ǥ�� ��ȯ
        startPos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));

        // �巡�� ���� ������ ��Ÿ�� ������Ʈ ����
        square = Instantiate(dragSquare, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void UpdateDragArea()
    {
        // ���� ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        nowPos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));

        // X�� ������ �巡�� �Ÿ� ���
        deltaX = Mathf.Abs(nowPos.x - startPos.x);

        // Y�� ������ �巡�� �Ÿ� ���
        deltaY = Mathf.Abs(nowPos.y - startPos.y);

        // �巡�� ������ �߽��� ���
        deltaPos = startPos + (nowPos - startPos) / 2;

        // ������Ʈ�� ��ġ�� �巡�� ������ �߽������� ����
        square.transform.position = deltaPos;

        // ������Ʈ�� ũ�⸦ �巡�� ������ �°� ����
        square.transform.localScale = new Vector3(deltaX, deltaY, 0);
    }
}
