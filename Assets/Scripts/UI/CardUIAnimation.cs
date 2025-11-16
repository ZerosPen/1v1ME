using UnityEngine;
using DG.Tweening;

public class CardUIAnimation : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private bool hasPlayedShowAnimation;

    [Header("References")]
    public RectTransform cardRect;
    public OnEndAnimationEventSO onEndAnimationEvent;
    public OnStartAnimationEventSO onStartAnimationEvent;
    public OnEndShowDownEventSO onEndShowDownEvent;

    [Header("Animation Settings")]
    public float CardPositionStart;
    public float CardPositionEnd;
    public float tweenTimes;

    private Tween currentTween;

    private void Awake()
    {
        cardRect = GetComponent<RectTransform>();
    }

    public void MoveCard()
    {
        // kill old tween to avoid stacking
        if (currentTween != null && currentTween.IsActive())
            currentTween.Kill();

        if (!hasPlayedShowAnimation)
        {
            currentTween = cardRect.DOAnchorPosY(CardPositionEnd, tweenTimes)
                .SetEase(Ease.OutQuad);
        }

        currentTween.OnComplete(() =>
        {
            if (!hasPlayedShowAnimation)
            {
                hasPlayedShowAnimation = true;
                AnimationManager.instance.ReportAnimationDone(); // battle triggers here
            }
        });
    }

    void ResetCard()
    {
        if (currentTween != null && currentTween.IsActive())
            currentTween.Kill();

        currentTween = cardRect.DOAnchorPosY(CardPositionStart, tweenTimes)
                              .SetEase(Ease.OutQuad);

        currentTween.OnComplete(() =>
        {
            hasPlayedShowAnimation = false;
        });
    }

    private void OnEnable()
    {
        onStartAnimationEvent.OnRaiseEvent += MoveCard;
        onEndShowDownEvent.OnRaiseEvent += ResetCard;
    }

    private void OnDisable()
    {
        onStartAnimationEvent.OnRaiseEvent -= MoveCard;
        onEndShowDownEvent.OnRaiseEvent -= ResetCard;
    }
}
