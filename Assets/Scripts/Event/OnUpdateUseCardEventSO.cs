using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Update UseCard Event"))]
public class OnUpdateUseCardEventSO : ScriptableObject
{
    public UnityAction<string, int> OnRaiseEvent;

    public void Raise(string nameCard, int value) => OnRaiseEvent?.Invoke(nameCard, value);
}
