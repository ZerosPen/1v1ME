using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (menuName = ("Events/On Send Use Card Event"))]
public class OnSendUseCardEventSO : ScriptableObject
{
    public UnityAction<int> OnRaiseEvent;

    public void Raise(int CountCard) => OnRaiseEvent?.Invoke(CountCard);
}
