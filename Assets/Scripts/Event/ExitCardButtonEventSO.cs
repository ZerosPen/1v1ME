using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/Exit Card Button Event"))]
public class ExitCardButtonEventSO : ScriptableObject
{
    public UnityAction<CardButton> OnRaiseEventExit;

    public void Raise(CardButton card)
    {
        OnRaiseEventExit?.Invoke(card);
    }
}
