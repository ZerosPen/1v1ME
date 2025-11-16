using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance;
    [SerializeField] private PlayerCharacter player;
    [SerializeField] private EnemyCharacter enemy;

    public EnemyEventSO enemyChanged;
    public PlayerCurrentEventSO playerSet;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    //Caclute Damage
    public void GetDealingDamage(string winner)
    {
       // Debug.Log($"[DamageManager] target = {winner}");
        if (winner == null) 
        {
            Debug.LogWarning("Target in Damage manager is empty!");
            return; 
        }

        //Debug.Log($"[DamageManager] DealDamage called by {winner}");

        if (winner.ToLower() == "player")
        {
            player.DealDamage(enemy);
        }
        else
        {
            enemy.DealDamage(player);
        }
    }

    public void OnEnable()
    {
        enemyChanged.OnEventRaise += SetEnemyCharacter;
        playerSet.OnEventRaise += SetPlayerCharacter;
    }

    private void OnDisable()
    {
        enemyChanged.OnEventRaise -= SetEnemyCharacter;
        playerSet.OnEventRaise -= SetPlayerCharacter;
    }

    void SetEnemyCharacter(EnemyCharacter newEnemy)
    {
        enemy = newEnemy;
    }

    void SetPlayerCharacter(PlayerCharacter newPlayer)
    {
        player = newPlayer;
    }
}
