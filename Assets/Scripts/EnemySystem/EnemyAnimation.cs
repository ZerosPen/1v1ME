using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [Header("Events")]
    public OnTriggerAttackEnemyEventSO onTriggerAttackEnemyEvent;
    public OnKillEnemyEventSO OnKillEnemyEvent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void PlayAttack()
    {
        Debug.Log("get called");
        _animator.SetTrigger("attack");
    }

    private void PlayDeathAnimation()
    {
        Debug.Log("get called");
        _animator.SetBool("isDead", true);
    }

    private void OnEnable()
    {
        onTriggerAttackEnemyEvent.OnRaiseEvent += PlayAttack;
        OnKillEnemyEvent.OnRaiseEvent += PlayDeathAnimation;
    }

    private void OnDisable()
    {
        onTriggerAttackEnemyEvent.OnRaiseEvent -= PlayAttack;
        OnKillEnemyEvent.OnRaiseEvent -= PlayDeathAnimation;
    }
}
