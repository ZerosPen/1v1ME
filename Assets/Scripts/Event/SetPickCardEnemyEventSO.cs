using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Set PickCard Enemy Event Channel")]
public class SetPickCardEnemyEventSO : ScriptableObject
{
    public UnityAction<EnemyPickCard> OnEventRaise;

    public void Raise(EnemyPickCard enemyPickCard)
    {
        OnEventRaise?.Invoke(enemyPickCard);
    }
}
