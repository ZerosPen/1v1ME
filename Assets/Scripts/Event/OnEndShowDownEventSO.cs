using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On End ShowDown Animation Event")]
public class OnEndShowDownEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Raise()
    {
        OnRaiseEvent?.Invoke();
    }
}
