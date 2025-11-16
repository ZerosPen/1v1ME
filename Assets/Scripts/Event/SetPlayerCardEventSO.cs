using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/Set Player Card Event"))]
public class SetPlayerCardEventSO : ScriptableObject
{
    public UnityAction<CardSO> OnRaiseEvent;

    public void Raise(CardSO card)
    {
        OnRaiseEvent?.Invoke(card);
    }
}
