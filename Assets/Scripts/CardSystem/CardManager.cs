using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    public List<CardButton> cards;

    [SerializeField] private CardButton _selectedButton;

    [Header("Events")]
    public HoverCardButtonEventSO hoverCardButtonEvent;
    public ExitCardButtonEventSO exitCardButtonEvent;
    public SelectedCardButtonEventSO selectedCardButtonEvent;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void OnCardHover(CardButton hovered)
    {
        foreach (var card in cards)
        {
            if (card != hovered && !card.GetIsSeleted())
                card.Shrink();
        }
    }

    public void OnCardExit(CardButton exitCard)
    {
        foreach (var card in cards)
        {
            if (!card.GetIsSeleted())
                card.ResetSize();
        }
    }

    public void OnCardSelected(CardButton selectedCard)
    {
        // Deselect previously selected
        if (_selectedButton != null && _selectedButton != selectedCard)
            _selectedButton.Deselect();

        _selectedButton = selectedCard;

        // Shrink ALL cards except the selected one
        foreach (var card in cards)
        {
            if (card != selectedCard)
                card.Shrink();
        }
    }

    public void CancelSelection()
    {
        if (_selectedButton != null)
        {
            _selectedButton.Deselect();
            _selectedButton = null;

            foreach (var card in cards)
                card.ResetSize();
        }
    }

    private void OnEnable()
    {
        hoverCardButtonEvent.OnRaiseEvent    += OnCardHover;
        exitCardButtonEvent.OnRaiseEventExit += OnCardExit;
        selectedCardButtonEvent.OnRaiseEvent += OnCardSelected;
    }

    private void OnDisable()
    {
        hoverCardButtonEvent.OnRaiseEvent    = OnCardHover;
        exitCardButtonEvent.OnRaiseEventExit = OnCardExit;
        selectedCardButtonEvent.OnRaiseEvent = OnCardSelected;
    }
}
