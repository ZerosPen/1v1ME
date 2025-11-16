using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [Header("Visuals")]
    public Image cardImage;

    public void ChangeCardUI(CardSO card)
    {
       if (card != null)
        {
            cardImage.sprite = card.cardSprite;
        }
    }

    public void ResetCardImageUI()
    {
        cardImage.sprite = null;
    }
}
