using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    private readonly float fixedValue = 17.856f; // 백그라운드 오브젝트 간의 거리

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        // 부딪힌 오브젝트 태그가 백그라운드라면
        if (collision.gameObject.CompareTag("BackGround"))
        {
            // 부모 오브젝트에서 Background 클래스 가져오기
            Background parent = collision.gameObject.GetComponentInParent<Background>();

            if (parent == null) { Debug.Log("Background를 찾지 못했습니다."); return; }


            float distance = 0f; // 거리를 저장할 변수
            Vector3 postion = new Vector3(); // 위치를 저장할 변수

            foreach(var image in parent.backGroundCloud)
            {
                // 가장 먼 거리 구하기
                if (Vector3.Distance(collision.gameObject.transform.position, image.transform.position) > distance)
                {
                    distance = Vector3.Distance(collision.gameObject.transform.position, image.transform.position);
                    postion = new Vector3(image.transform.position.x + fixedValue, 0, 0);
                }
            }

            // 가장 먼거리의 오브젝트의 (x값 + 고정값, 0, 0) 으로 위치 변경
            collision.gameObject.transform.position = postion;
        }
    }
}
