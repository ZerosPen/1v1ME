using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On Player Killed Event")]
public class OnPlayerKilledSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Riase() => OnRaiseEvent?.Invoke();
}
