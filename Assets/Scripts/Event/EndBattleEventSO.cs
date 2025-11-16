using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/End Battle Event"))]
public class EndBattleEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Raise()
    {
        OnRaiseEvent?.Invoke(); 
    }
}
