using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [Header("Events")]
    public OnTriggerAttackPlayerEventSO onTriggerAttackPlayerEvent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }

    public void PlayDeadAnimation()
    {
        _animator.SetBool("isDead", true);
    }

    private void OnEnable()
    {
        onTriggerAttackPlayerEvent.OnRaiseEvent += PlayAttackAnimation;
    }

    private void OnDisable()
    {
        onTriggerAttackPlayerEvent.OnRaiseEvent -= PlayAttackAnimation;
    }
}
