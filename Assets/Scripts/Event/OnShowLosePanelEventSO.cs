using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On Show Lose Panel Event")]
public class OnShowLosePanelEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Riase() => OnRaiseEvent?.Invoke();
}
