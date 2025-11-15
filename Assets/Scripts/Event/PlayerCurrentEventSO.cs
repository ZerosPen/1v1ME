using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Player Current Event Channel")]
public class PlayerCurrentEventSO : ScriptableObject
{
    public UnityAction<PlayerCharacter> OnEventRaise;

    public void Raise(PlayerCharacter player)
    {
        OnEventRaise?.Invoke(player);
    }
}
