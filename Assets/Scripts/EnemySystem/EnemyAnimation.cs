using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [Header("Events")]
    public OnTriggerAttackEnemyEventSO onTriggerAttackEnemyEvent;
    public OnKillEnemyEventSO OnKillEnemyEvent;
    public OnCanSpawnEventSO OnCanSpawnEvent;

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
        //StartCoroutine(WaitDeathAnimation());
        _animator.SetBool("isDead", true);
        StartCoroutine(WaitDeathAnimation());
    }

    private IEnumerator WaitDeathAnimation()
    {
        Debug.Log("get called");

        AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);

        yield return new WaitForSeconds(info.length);

        OnCanSpawnEvent.Raise();
        Debug.Log("Enemy death animation finished!");
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
