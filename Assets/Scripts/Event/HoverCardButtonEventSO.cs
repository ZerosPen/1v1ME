using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/Hover Card Button Event"))]
public class HoverCardButtonEventSO : ScriptableObject
{
    public UnityAction<CardButton> OnRaiseEvent;

    public void Raise(CardButton card)
    {
        OnRaiseEvent?.Invoke(card);
    }
}
