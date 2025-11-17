using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [Header("Status")]
    [SerializeField] private int killedEnemy;
    [SerializeField] private string winner;
    [SerializeField] private CardSO _playerCard;
    [SerializeField] private CardSO _enemyCard;
    [SerializeField] private int BestScore;
    [SerializeField] private bool _canGetScore = true;

    [Header("Events")]
    public OnKillEnemyEventSO onKilledEnemyEvent;
    public EndBattleEventSO endBattleEvent;
    public OnStartShowDownEventSO onStartShowDownEvent;
    public OnEndShowDownEventSO onEndShowDownEventSO;
    public OnChangeWinnerEventSO onChangeWinnerEvent;
    public OnTriggerAttackPlayerEventSO onTriggerAttackPlayerEvent;
    public OnTriggerAttackEnemyEventSO onTriggerAttackEnemyEvent;
    public OnSendKilledCountEventSO onSendKilledCountEvent;
    public OnGetStatusEventSO onGetStatusEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MusicManager.instance.PlayMusic("BGM1");
    }

    public void BattleStart(CardSO playerCard, CardSO enemyCard)
    {
        winner = DeciderManager.instance.DicideringCard();
        _playerCard = playerCard;
        _enemyCard = enemyCard;
        onStartShowDownEvent.Raise();
    }

    public void DoBattle()
    {
        if (winner != null)
        {
            DamageManager.instance.GetDealingDamage(winner);
        }
        _playerCard = _enemyCard = null;
        winner = null;

        endBattleEvent.Raise();
    }

    private void CountKilled()
    {
        onSendKilledCountEvent.Raise(killedEnemy);
    }

    private void ShowWinner()
    {
        onChangeWinnerEvent.Raise(winner, _playerCard, _enemyCard);
        // 2) Wait then finish
        StartCoroutine(ShowWinnerDelay());
    }

    private IEnumerator ShowWinnerDelay()
    {
        yield return new WaitForSeconds(2f);

        UIManager.instance.onEndShowDownEvent.Raise();

        if (winner == "player")
            onTriggerAttackPlayerEvent.Raise();
        else if (winner == "enemy")
            onTriggerAttackEnemyEvent.Raise();

        yield return new WaitForSeconds(0.2f);

        DoBattle();
    }

    public void OnkilledEnemy()
    {
       if (_canGetScore)
        {
            killedEnemy++;
            ScoreManager.instance.AddScore(BestScore);
            _canGetScore = false;
            StartCoroutine(DelayDefaulting());
        }
    }

    private IEnumerator DelayDefaulting()
    {
        yield return new WaitForSeconds(0.2f);
        _canGetScore = true;
    }

    private void OnEnable()
    {
        onKilledEnemyEvent.OnRaiseEvent  += OnkilledEnemy;
        AnimationManager.instance.OnAllAnimationsDone += ShowWinner;
        onGetStatusEvent.OnRaiseEvent += CountKilled;
    }

    private void OnDisable()
    {
        onKilledEnemyEvent.OnRaiseEvent  -= OnkilledEnemy;
        AnimationManager.instance.OnAllAnimationsDone -= ShowWinner;
        onGetStatusEvent.OnRaiseEvent -= CountKilled;
    }

}
