using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Send Score Event"))]
public class OnSendScoreEventSO : ScriptableObject
{
    public UnityAction<int> OnRaiseEvent;

    public void Raise(int CountScore) => OnRaiseEvent?.Invoke(CountScore);
}
