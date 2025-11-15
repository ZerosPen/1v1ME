using UnityEngine;
using UnityEngine.Events;

public class CurrentEnemyHandler : MonoBehaviour
{
    public EnemyEventSO enemyChangeEvent;

    public void SetEnemy(EnemyCharacter enemy)
    {
        enemyChangeEvent.Raise(enemy);
    }
}
