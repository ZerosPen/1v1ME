using UnityEngine;
using DG.Tweening;

public class CardUIAnimation : MonoBehaviour
{
    [Header("Refencses")]
    public RectTransform cardRect;

    [Header("Animation Settings")]
    public float CardPositionStart;
    public float CardPositionEnd;
    public float tweenTimes;

    [Header("Events")]
    public float CardPositionStat;

    private Tween currentTween;

    public void MoveCard()
    {
        cardRect.DOMoveY(CardPositionStart, tweenTimes);
    }
}
