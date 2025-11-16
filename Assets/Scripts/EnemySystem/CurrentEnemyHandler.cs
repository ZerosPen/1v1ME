using UnityEngine;
using UnityEngine.Events;

public class CurrentEnemyHandler : MonoBehaviour
{
    [Header("Events")]
    public EnemyEventSO enemyChangeEvent;
    public SetPickCardEnemyEventSO EnemyPickCardEvetChannel;
    public OnKillEnemyEventSO EnemyKillEventChannel;

    public void SetEnemy(EnemyCharacter enemy)
    {
        enemyChangeEvent.Raise(enemy);
    }

    public void SetPickUpCardEnemy(EnemyPickCard enemyPickUpCard)
    {
        EnemyPickCardEvetChannel.Raise(enemyPickUpCard);
    }

    public void SetEnemyKillEventChannel()
    {
        EnemyKillEventChannel.Raise();
    }
}
