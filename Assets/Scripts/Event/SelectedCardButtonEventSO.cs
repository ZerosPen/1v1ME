using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/Selected Card Button Event"))]
public class SelectedCardButtonEventSO : ScriptableObject
{
    public UnityAction<CardButton> OnRaiseEvent;

    public void Raise(CardButton card)
    {
        OnRaiseEvent?.Invoke(card);
    }
}
