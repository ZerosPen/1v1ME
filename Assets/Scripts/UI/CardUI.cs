using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [Header("Visuals")]
    public Image cardImage;

    public void ChangeCardUI(CardSO card)
    {
        cardImage.sprite = card.cardSprite;
    }
}
