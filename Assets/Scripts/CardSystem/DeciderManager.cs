using System.Collections;
using UnityEngine;

public class DeciderManager : MonoBehaviour
{
    public static DeciderManager instance;
    public DiciderCard diciderCard;
    [SerializeField] private bool battleTriggered;

    private CardSO playerCard;
    private CardSO enemyCard;

    [Header("Events")]
    public EndBattleEventSO endBattleEvent;

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

    private void PlayerandEnemyHaveCard()
    {
        if (battleTriggered)
            return;

        //Debug.Log($"[Decider] playerCard={playerCard != null}, enemyCard={enemyCard != null}");
        if (playerCard != null && enemyCard != null)
        {
            battleTriggered = true;
            //Debug.Log($"[Decider] battleTriggered={battleTriggered}");
            BattleManager.instance.BattleStart();
        }
            
    }

    public string DicideringCard()
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
        return winner;
    }

    public void SetPlayerCard(CardSO card)
    {
        playerCard = card;
        TurnManager.instance.ChangeTurn();
        PlayerandEnemyHaveCard();
    }

    public void SetEnemyCard(CardSO card)
    {
        enemyCard = card;
        TurnManager.instance.ChangeTurn();
        PlayerandEnemyHaveCard();
    }

    private void DelayDefaulting()
    {
        playerCard = enemyCard = null;
        battleTriggered = false;
    }

    private void OnEnable()
    {
        endBattleEvent.OnRaiseEvent += DelayDefaulting;
    }

    private void OnDisable()
    {
        endBattleEvent.OnRaiseEvent -= DelayDefaulting;
    }
}
