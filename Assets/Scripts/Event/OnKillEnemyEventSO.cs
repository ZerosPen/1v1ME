using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On Killed Enemy Event")]
public class OnKillEnemyEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Raise()
    {
        OnRaiseEvent?.Invoke();
    }
}
