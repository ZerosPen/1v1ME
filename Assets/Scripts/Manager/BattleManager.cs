using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [Header("Events")]
    public OnKillEnemyEventSO onKilledEnemyEvent;
    public EndBattleEventSO endBattleEvent;

    [SerializeField] private int killedEnemy;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void BattleStart()
    {
        string winner = DeciderManager.instance.DicideringCard();
        //Debug.Log($"[BattleManager] Winner = {winner}");

        if (winner != null)
        {
            DamageManager.instance.GetDealingDamage(winner);
        }
        endBattleEvent.Raise();
    }

    public void OnkilledEnemy()
    {
        killedEnemy++;
        ScoreManager.instance.AddScore(100);
    }

    private void OnEnable()
    {
        onKilledEnemyEvent.OnRaiseEvent += OnkilledEnemy;
    }

    private void OnDisable()
    {
        onKilledEnemyEvent.OnRaiseEvent -= OnkilledEnemy;
    }

}
