using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "Scriptable Object/CharacterScriptableObject", order = int.MaxValue)]
public class CharacterScriptableObject : ScriptableObject
{
    public Sprite sprite;
    public Vector2 scale;
    public int price;
}
