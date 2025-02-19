using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager instance;

    public Character currentCharacter = Character.Knight;
    public Character returnCharacter;
    public List<Character> unlockCharacters = new List<Character>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        unlockCharacters.Add(currentCharacter);
    }
}
