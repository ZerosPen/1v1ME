using UnityEngine;
using UnityEngine.Events;

public class ReadyButton : MonoBehaviour
{
    public HideShowReadyButtonEventSO hideShowReadyButtonEvent;
    public UnityEvent OnRaiseEvent;

    public void OnClickReady()
    {
        OnRaiseEvent.Invoke();
        hideShowReadyButtonEvent.Raise(false);
    }
}
