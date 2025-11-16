using UnityEngine;
using DG.Tweening;

public class LosePanelUI : MonoBehaviour
{
    [Header("setting Fading")]
    public float timeFadingIn;
    public float timeFadingOut;

    [Header("Refence")]
    [SerializeField] private CanvasGroup _cg;

    [Header("Events")]
    public OnShowLosePanelEventSO onShowLosePanelEvent;
    public OnHideLosePanelEventSO onHideLosePanelEvent;

    private Tween DG;

    public void FadeInPanel()
    {
        if (_cg == null)
            _cg = GetComponent<CanvasGroup>();

        _cg.alpha = 0;

        DG = _cg.DOFade(1f, timeFadingIn).SetEase(Ease.OutQuad);
    }

    public void FadeOutPanel()
    {
        if (_cg == null)
            _cg = GetComponent<CanvasGroup>();

        DG = _cg.DOFade(0f, timeFadingOut)
            .SetEase(Ease.InQuad)
            .OnComplete(() => onHideLosePanelEvent.Riase());
    }

    private void OnEnable()
    {
        onShowLosePanelEvent.OnRaiseEvent += FadeInPanel;
    }

    private void OnDisable()
    {
        onShowLosePanelEvent.OnRaiseEvent -= FadeInPanel;
    }
}
