using UnityEngine;
using UnityEngine.Events;

/*
 This class is use for event without arguments
 */

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityEvent OnRaiseEvent;

    public void RaiseEvent()
    {
        OnRaiseEvent?.Invoke();
    }
}
