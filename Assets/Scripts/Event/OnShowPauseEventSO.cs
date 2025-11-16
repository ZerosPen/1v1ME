using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Show Pause Event"))]
public class OnShowPauseEventSO : ScriptableObject
{
    public UnityAction<bool> OnRaiseEvent;

    public void Raise(bool isTop) => OnRaiseEvent?.Invoke(isTop);
}
