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
        Vector2 firstPos = new Vector2(posX, posY);

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                GameObject go = Instantiate(numberPrefabs[Random.Range(0, 9)], transform);
                go.transform.localPosition = new Vector2(posX, posY);
                inGameNumbers.Add(go);

                posX += 0.7f;
            }
            posX = firstPos.x;
            posY -= 0.8f;
        }
    }
}
