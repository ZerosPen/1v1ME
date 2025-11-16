using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardController : MonoBehaviour
{
    [SerializeField] private CardSO card;

    [Header("Events")]
    public SetPlayerCardEventSO setPlayerCardEvent;
    public CanPickUpCardEventSO canPickUpCardEvent;
    public EndBattleEventSO endBattleEvent;
    public OnChangeCardEventSO onChangeCardEvent;

    public void LockPlayerCard()
    {
        DeciderManager.instance.SetPlayerCard(card);
        onChangeCardEvent.Raise(card.cardName.ToLower(), 1);
    }

    private void SetPlayerCardController(CardSO newCard)
    {
        card = newCard;
        canPickUpCardEvent.Raise(false);
    }

    public void DefaultingSettings()
    {
        card = null;
        canPickUpCardEvent.Raise(true);
    }

    private void OnEnable()
    {
        setPlayerCardEvent.OnRaiseEvent += SetPlayerCardController;
        endBattleEvent.OnRaiseEvent += DefaultingSettings;
    }
    private void OnDisable()
    {
        setPlayerCardEvent.OnRaiseEvent -= SetPlayerCardController;
        endBattleEvent.OnRaiseEvent -= DefaultingSettings;
    }
}
