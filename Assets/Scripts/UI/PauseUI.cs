using UnityEngine;
using DG.Tweening;

public class PauseUI : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private bool isPauseOpen;

    [Header("Hide or Show Settings")]
    public float TopStart;
    public float TopEnd;
    public float BottomStart;
    public float BottomEnd;
    public float tweenTime = 0.5f;

    [Header("Events")]
    public OnShowPauseEventSO OnShowPauseEvent;

    private RectTransform _rt;
    private Tween DG;

    private void Awake()
    {
        _rt = GetComponent<RectTransform>();
    }

    private void DecidePause(bool isTop)
    {
        if (!isPauseOpen)
            ShowPausePanel(isTop);
        else
            HidePausePanel(isTop);
    }

    // Call this to show panel
    public void ShowPausePanel(bool isTop)
    {
        // Kill existing tween if any
        DG?.Kill();

        float startPos = isTop ? TopStart : BottomStart;
        float endPos = isTop ? TopEnd : BottomEnd;

        // Set starting position immediately
        Vector2 anchoredPos = _rt.anchoredPosition;
        anchoredPos.y = startPos;
        _rt.anchoredPosition = anchoredPos;

        // Animate to end position
        DG = _rt.DOAnchorPosY(endPos, tweenTime).SetEase(Ease.InOutSine);
        isPauseOpen = true;
    }

    // Optional: Hide panel
    public void HidePausePanel(bool isTop)
    {
        DG?.Kill();

        float startPos = isTop ? TopStart : BottomStart;
        float endPos = isTop ? TopEnd : BottomEnd;

        Vector2 anchoredPos = _rt.anchoredPosition;
        anchoredPos.y = endPos;
        _rt.anchoredPosition = anchoredPos;

        DG = _rt.DOAnchorPosY(startPos, tweenTime).SetEase(Ease.InOutSine);
        isPauseOpen = false;
    }

    private void OnEnable()
    {
        OnShowPauseEvent.OnRaiseEvent += DecidePause;
    }

    private void OnDisable()
    {
        OnShowPauseEvent.OnRaiseEvent -= DecidePause;
    }
}
