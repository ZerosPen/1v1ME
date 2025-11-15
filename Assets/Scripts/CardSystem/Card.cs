using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour, Iinteractable
{
    [SerializeField] private CardSO card;
    [SerializeField] private Image cardBackGround;

    private void Start()
    {
        if (card != null || cardBackGround != null)
        {
            cardBackGround.sprite = card.cardSprite;
        }
        else
        {
            Debug.LogWarning("CardSO or CardBackGround are missing form card!");
        }
    }

    public void interact()
    {
        if (card != null && TurnManager.instance.GetTurn())
        {
            Debug.Log($"You just clicked card : {card.cardName}");
            DeciderManager.instance.SetPlayerCard(card);
        }
        else
        {
            Debug.Log("Try to use the card!");
        }
    }
}
