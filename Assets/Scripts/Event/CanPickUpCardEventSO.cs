using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Can PickUp Card Event")]
public class CanPickUpCardEventSO : ScriptableObject
{
    public UnityAction<bool> OnRaiseEvent;

    public void Raise (bool canPickUpCard)
    {
        OnRaiseEvent?.Invoke(canPickUpCard);
    }
}
