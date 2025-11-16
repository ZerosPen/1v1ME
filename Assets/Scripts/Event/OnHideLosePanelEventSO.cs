using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (menuName = "Events/On Hide Lose Panel Event")]
public class OnHideLosePanelEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Riase() => OnRaiseEvent?.Invoke();
}
