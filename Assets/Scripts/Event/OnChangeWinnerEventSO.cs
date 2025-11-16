using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On Change Winner Event")]
public class OnChangeWinnerEventSO : ScriptableObject
{
    public UnityAction<string, CardSO, CardSO> OnRaiseEvent;

    public void Raise(string winner, CardSO playerCard, CardSO enemyCard)
    {
        OnRaiseEvent?.Invoke(winner, playerCard, enemyCard);
    }
}
