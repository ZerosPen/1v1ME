using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPickCard : MonoBehaviour
{
    [Header("List of Card")]
    public List<CardSO> cards = new List<CardSO>();

    private CurrentEnemyHandler currentEnemyHandler;

    private void Start()
    {
        SetCurrentEnemy();
    }

    public void EnemyPickingCard()
    {
        DeciderManager.instance.SetEnemyCard(RandomPickCard());
    }

    private CardSO RandomPickCard()
    {
        if (cards == null || cards.Count == 0)
        {
            Debug.LogError("Enemy card list is empty!");
            return null;
        }

        int randomIndex = Random.Range(0, cards.Count);

        CardSO card = cards[randomIndex];
        return card;
    }

    private void SetCurrentEnemy()
    {
        if (currentEnemyHandler == null)
        {
            currentEnemyHandler = GameObject.FindGameObjectWithTag("EventEnemyHandler")
                                            .GetComponent<CurrentEnemyHandler>();
        }
        currentEnemyHandler.SetPickUpCardEnemy(this);
    }
}
