using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("CharacterSO"), fileName = "CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string nameCharacter;
    public Sprite spriteCharacter;
    public float healtPointCharacter;
    public float dealDamageCharacter;
}
