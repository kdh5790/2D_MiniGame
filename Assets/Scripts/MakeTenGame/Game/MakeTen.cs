using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTen : MonoBehaviour
{
    public static MakeTen instance;

    public List<GameObject> selectedNumber = new List<GameObject>();
    public int sum;

    public bool isDead = true; 

    private void Awake()
    {
        if (instance == null)
            instance = this;

        sum = 0;
    }
}
