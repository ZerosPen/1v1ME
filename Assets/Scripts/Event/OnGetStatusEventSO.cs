using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Get Status Event"))]
public class OnGetStatusEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;

    public void Raise() => OnRaiseEvent?.Invoke();
}
