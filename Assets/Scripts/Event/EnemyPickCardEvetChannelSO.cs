using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Enemy PickCard Event Channel")]
public class EnemyPickCardEvetChannelSO : ScriptableObject
{
    public UnityEvent OnRaiseEvent;

    public void RaiseEvent()
    {
        OnRaiseEvent?.Invoke();
    }
}
