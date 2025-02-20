using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager instance;

    public Character currentCharacter = Character.Knight; // �÷��̾��� ���� ĳ����
    public Character returnCharacter; // �÷��̾ ������ ������ ĳ����(���� ĳ���� Ÿ�� ������ �Ǻ��ϱ� ���� ����)
    public List<Character> unlockCharacters = new List<Character>(); // ���� �ر��� ĳ���͵�

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
