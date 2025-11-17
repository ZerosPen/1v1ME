using UnityEngine;
using DG.Tweening;
using TMPro;

public class LosePanelUI : MonoBehaviour
{
    [Header("setting Fading")]
    public float timeFadingIn;
    public float timeFadingOut;

    [Header("Refence")]
    [SerializeField] private CanvasGroup _cg;
    public TextMeshProUGUI actioCard;
    public TextMeshProUGUI score;
    public TextMeshProUGUI killedEnemy;


    [Header("Events")]
    public OnShowLosePanelEventSO onShowLosePanelEvent;
    public OnGetStatusEventSO onGetStatusEvent;
    public OnSendKilledCountEventSO onSendKilledCountEvent;
    public OnSendScoreEventSO onSendScoreEvent;
    public OnSendUseCardEventSO onSendUseCardEvent;

    private Tween DG;

    public void FadeInPanel()
    {
        if (_cg == null)
            _cg = GetComponent<CanvasGroup>();

        _cg.alpha = 0;

        DG = _cg.DOFade(1f, timeFadingIn).SetEase(Ease.OutQuad)
            .OnComplete(() => onGetStatusEvent.Raise());
    }

    public void FadeOutPanel()
    {
        if (_cg == null)
            _cg = GetComponent<CanvasGroup>();

        DG = _cg.DOFade(0f, timeFadingOut)
            .SetEase(Ease.InQuad);
    }

    public void UpdateCardUseUI(int cardUse)
    {
        actioCard.text = cardUse.ToString();
    }
    public void UpdateScorePlayerUI(int scorePlayer)
    {
        score.text = scorePlayer.ToString();
    }
    public void UpdatekilledEnemyUI(int killed)
    {
        killedEnemy.text = killed.ToString();
    }

    private void OnEnable()
    {
        onShowLosePanelEvent.OnRaiseEvent += FadeInPanel;
        onSendKilledCountEvent.OnRaiseEvent += UpdatekilledEnemyUI;
        onSendScoreEvent.OnRaiseEvent += UpdateScorePlayerUI;
        onSendUseCardEvent.OnRaiseEvent += UpdateCardUseUI;
    }

    private void OnDisable()
    {
        onShowLosePanelEvent.OnRaiseEvent -= FadeInPanel;
        onSendKilledCountEvent.OnRaiseEvent -= UpdatekilledEnemyUI;
        onSendScoreEvent.OnRaiseEvent -= UpdateScorePlayerUI;
        onSendUseCardEvent.OnRaiseEvent -= UpdateCardUseUI;
    }
}
