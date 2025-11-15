using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerHandler : MonoBehaviour
{
    public PlayerCurrentEventSO SetPlayerEvent;

    public void SetPlayer(PlayerCharacter player)
    {
        SetPlayerEvent.Raise(player);
    }
}
