using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On Start Animation Event")]
public class OnStartAnimationEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Raise()
    {
        OnRaiseEvent?.Invoke();
    }
}
