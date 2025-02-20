using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager instance;

    public Character currentCharacter = Character.Knight; // 플레이어의 현재 캐릭터
    public Character returnCharacter; // 플레이어가 이전에 장착한 캐릭터(랜서 캐릭터 타고 내릴때 판별하기 위한 변수)
    public List<Character> unlockCharacters = new List<Character>(); // 현재 해금한 캐릭터들

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
