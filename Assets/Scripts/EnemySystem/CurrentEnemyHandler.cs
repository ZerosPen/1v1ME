using UnityEngine;
using UnityEngine.Events;

public class CurrentEnemyHandler : MonoBehaviour
{
    public EnemyEventSO enemyChangeEvent;
    public SetPickCardEnemyEventSO EnemyPickCardEvetChannel;

    public void SetEnemy(EnemyCharacter enemy)
    {
        enemyChangeEvent.Raise(enemy);
    }

    public void SetPickUpCardEnemy(EnemyPickCard enemyPickUpCard)
    {
        EnemyPickCardEvetChannel.Raise(enemyPickUpCard);
    }
}
