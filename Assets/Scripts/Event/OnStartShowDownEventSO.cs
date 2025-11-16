using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On Start ShowDown Animation Event")]
public class OnStartShowDownEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Raise()
    {
        OnRaiseEvent?.Invoke();
    }
}
