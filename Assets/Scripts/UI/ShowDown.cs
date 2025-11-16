using TMPro;
using UnityEngine;

public class ShowDown : MonoBehaviour
{
    [SerializeField] private CardUI _playerCard;
    [SerializeField] private CardUI _enemyCard;
    public TextMeshProUGUI winnerText;

    [Header("Events")]
    public OnChangeWinnerEventSO onChangeWinnerEvent;
    public EndBattleEventSO EndBattleEvent;

    public void RevealCardWinner(string winner, CardSO playerCard, CardSO enemyCard)
    {
        _playerCard.ChangeCardUI(playerCard);
        _enemyCard.ChangeCardUI(enemyCard);
         if (string.IsNullOrEmpty(winner))
        {
            winnerText.text = "Draw Card";
        }
        else
        {
            winnerText.text = winner.ToUpper() + " WIN";
        }
    }

    public void ResetShowDown()
    {
        _playerCard.ResetCardImageUI();
        _enemyCard.ResetCardImageUI();
        winnerText.text = "";
    }

    private void OnEnable()
    {
        onChangeWinnerEvent.OnRaiseEvent += RevealCardWinner;
        EndBattleEvent.OnRaiseEvent += ResetShowDown;
    }

    private void OnDisable()
    {
        onChangeWinnerEvent.OnRaiseEvent -= RevealCardWinner;
        EndBattleEvent.OnRaiseEvent -= ResetShowDown;
    }
}
