using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/Hide Show Ready Button Event"))]
public class HideShowReadyButtonEventSO : ScriptableObject
{
    public UnityAction<bool> OnRaiseEvent;

    public void Raise(bool isShowReadyButton)
    {
        OnRaiseEvent?.Invoke(isShowReadyButton);
    }
}
