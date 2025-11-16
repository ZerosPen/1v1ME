using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On End Animation Event")]
public class OnEndAnimationEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Raise()
    {
        OnRaiseEvent?.Invoke();
    }
}
