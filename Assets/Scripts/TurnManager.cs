using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    [Header("Status Battle")]
    [SerializeField] private bool isPlayerTurn = true;

    [Header("References")]
    [SerializeField] private EnemyPickCard _enemyPickCard;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        if (_enemyPickCard != null && !isPlayerTurn)
        {
            _enemyPickCard.EnemyPickingCard();
        }
    }

    public bool GetTurn()
    {
        return isPlayerTurn;
    }
}
