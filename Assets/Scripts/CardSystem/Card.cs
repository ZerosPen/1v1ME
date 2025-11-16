using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour, Iinteractable
{
    [SerializeField] private CardSO card;
    [SerializeField] private Image cardBackGround;
    
    [Header("Events")]
    public SetPlayerCardEventSO setPlayerCardEvent;
    public HideShowReadyButtonEventSO hideShowReadyButtonEvent;

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
            //DeciderManager.instance.SetPlayerCardController(card);
            setPlayerCardEvent.Raise(card);
            hideShowReadyButtonEvent.Raise(true);
        }
        else
        {
            Debug.Log("Try to use the card!");
        }
    }
}
