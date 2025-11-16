using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On Change Card Event")]
public class OnChangeCardEventSO : ScriptableObject
{
    public UnityAction<string, int> OnRaiseEvent;

    public void Raise(string nameCard, int value) => OnRaiseEvent?.Invoke(nameCard, value);
}
