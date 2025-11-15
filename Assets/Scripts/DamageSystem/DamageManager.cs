using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance;
    [SerializeField] private PlayerCharacter player;
    [SerializeField] private EnemyCharacter enemy;

    public EnemyEventSO enemyChanged;
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetDealingDamage(string winner)
    {
        if (player == null || enemy == null)
            return;
        
        if (winner != null)
        {
            if (winner.ToLower() == "player")
            {
                player.DealDamage(enemy);
            }
            else
            {
                enemy.DealDamage(player);
            }
        }
    }

    public void OnEnable()
    {
        enemyChanged.OnEventRaise += SetEnemyCharacter;
    }

    private void OnDisable()
    {
        enemyChanged.OnEventRaise -= SetEnemyCharacter;
    }

    void SetEnemyCharacter(EnemyCharacter newEnemy)
    {
        enemy = newEnemy;
    }
}
