using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Enemy Event")]
public class EnemyEventSO : ScriptableObject
{
    public UnityAction<EnemyCharacter> OnEventRaise;

    public void Raise(EnemyCharacter enemy)
    {
        OnEventRaise?.Invoke(enemy);
    }
}
