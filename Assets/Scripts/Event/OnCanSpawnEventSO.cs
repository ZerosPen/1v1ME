using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName =("Events/On Can Spawn Event"))]
public class OnCanSpawnEventSO : ScriptableObject
{
    public UnityAction OnRiaseEvent;

    public void Raise() => OnRiaseEvent?.Invoke();
}
