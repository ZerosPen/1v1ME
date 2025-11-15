using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("CardSO"), fileName = "CardSO")]
public class CardSO : ScriptableObject
{
    public string cardName;
    public Sprite cardSprite;
}
