using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CancelButton : MonoBehaviour
{
    public HideShowReadyButtonEventSO hideShowReadyButtonEvent;
    public UnityEvent OnRaiseEvent;

    public void OnClickCancel()
    {
        OnRaiseEvent.Invoke();
        hideShowReadyButtonEvent.Raise(false);
    }
}
