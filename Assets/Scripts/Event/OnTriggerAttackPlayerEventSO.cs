using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Trigger Attack Player Event"))]
public class OnTriggerAttackPlayerEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Raise () => OnRaiseEvent?.Invoke();
}
