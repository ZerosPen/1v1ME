using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Events")]
    public OnShowPauseEventSO OnShowPauseEvent;

    public void PressPauseButton(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            OnShowPauseEvent.Raise(false);
        }
    }
}
