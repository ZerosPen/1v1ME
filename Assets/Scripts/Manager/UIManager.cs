using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("References")]
    public GameObject ReadyOrCancelButton;
    public GameObject ShowDownPanel;
    public GameObject LosePanel;

    [Header("Events")]
    public HideShowReadyButtonEventSO HideShowReadyButtonEvent;
    public OnStartShowDownEventSO OnStartShowDownEvent;
    public OnEndShowDownEventSO onEndShowDownEvent;
    public OnStartAnimationEventSO onStartAnimationEvent;
    public OnShowLosePanelEventSO onShowLosePanelEvent;
    public OnHideLosePanelEventSO onHideLosePanelEvent;
    public OnPlayerKilledSO onPlayerKilledEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void ShowLosePanel()
    {
        LosePanel.SetActive(true);
        onShowLosePanelEvent.Riase();
    }

    private void HideLosePanel()
    {
        LosePanel.SetActive(false);
    }

    private void ShowDownCard()
    {
        ShowDownPanel.SetActive(true);
        onStartAnimationEvent.Raise();
    }

    private void HideShowDownCard()
    {
        ShowDownPanel.SetActive(false);
    }

    public void HideOrShowReadyButton(bool isShow)
    {
        ReadyOrCancelButton.SetActive(isShow);
    }

    private void OnEnable()
    {
        HideShowReadyButtonEvent.OnRaiseEvent  += HideOrShowReadyButton;
        OnStartShowDownEvent.OnRaiseEvent      += ShowDownCard;
        onEndShowDownEvent.OnRaiseEvent        += HideShowDownCard;
        onHideLosePanelEvent.OnRaiseEvent      += HideLosePanel;
        onPlayerKilledEvent.OnRaiseEvent       += ShowLosePanel;
    }

    private void OnDisable()
    {
        HideShowReadyButtonEvent.OnRaiseEvent   -= HideOrShowReadyButton;
        OnStartShowDownEvent.OnRaiseEvent       -= ShowDownCard;
        onEndShowDownEvent.OnRaiseEvent         -= HideShowDownCard;
        onHideLosePanelEvent.OnRaiseEvent       -= HideLosePanel;
        onPlayerKilledEvent.OnRaiseEvent        -= ShowLosePanel;
    }
}
