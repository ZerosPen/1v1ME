using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Send Killed Count Event"))]
public class OnSendKilledCountEventSO : ScriptableObject
{
    public UnityAction<int> OnRaiseEvent;

    public void Raise(int CountKilled) => OnRaiseEvent?.Invoke(CountKilled);
}
