using System.Collections;
using UnityEngine;

public class DeciderManager : MonoBehaviour
{
    public static DeciderManager instance;
    public DiciderCard diciderCard;

    [SerializeField] private CardSO playerCard;
    [SerializeField] private CardSO enemyCard;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TryDeciding()
    {
        if (playerCard != null && enemyCard != null)
            StartCoroutine(countDownDicidering());
    }

    private void DicideringCard()
    {
        string winnerCard = diciderCard.GetDeciderCard(playerCard, enemyCard);
        string winner = null;

        if (winnerCard == "draw")
        {
            Debug.Log($"Player and Enemy have same card {playerCard.cardName} and {enemyCard.cardName}");
        }
        else if (winnerCard == playerCard.cardName.ToLower())
        {
            //deal damage to enemy
            Debug.Log($"Player are the winnerCard because {playerCard.cardName} is beat {enemyCard.cardName}");
            winner = "player";
        }
        else if (winnerCard == enemyCard.cardName.ToLower())
        {
            //deal damage to player
            Debug.Log($"Enemy are the winnerCard because {enemyCard.cardName} is beat {playerCard.cardName}");
            winner = "enemy";
        }
        DamageManager.instance.GetDealingDamage(winner);
        StartCoroutine(DelayDefaulting());
    }

    public void SetPlayerCard(CardSO card)
    {
        playerCard = card;
        TurnManager.instance.ChangeTurn();
        TryDeciding();
    }

    public void SetEnemyCard(CardSO card)
    {
        enemyCard = card;
        TurnManager.instance.ChangeTurn();
        TryDeciding();
    }

    private IEnumerator DelayDefaulting()
    {
        yield return new WaitForSeconds(1f);
        playerCard = enemyCard = null;
    }

    public IEnumerator countDownDicidering()
    {
        yield return new WaitForSeconds(1f);
        DicideringCard();
    }
}
