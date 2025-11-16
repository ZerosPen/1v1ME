using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Trigger Attack Enemy Event"))]
public class OnTriggerAttackEnemyEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;
    
    public void Raise() => OnRaiseEvent?.Invoke();
}
