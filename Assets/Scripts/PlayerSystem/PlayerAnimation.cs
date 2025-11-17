using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [Header("Events")]
    public OnTriggerAttackPlayerEventSO onTriggerAttackPlayerEvent;
    public OnPlayerKilledSO onPlayerKilledEvent;
    public OnShowLosePanelEventSO onShowLosePanelEvent;

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
        StartCoroutine(DelayLosePanel());
    }

    private IEnumerator DelayLosePanel()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        yield return new WaitForSeconds(stateInfo.length);
        //Raise a event
        Debug.Log("Dead animation finished!");
        UIManager.instance.ShowLosePanel();
    }

    private void OnEnable()
    {
        onTriggerAttackPlayerEvent.OnRaiseEvent += PlayAttackAnimation;
        onPlayerKilledEvent.OnRaiseEvent += PlayDeadAnimation;
    }

    private void OnDisable()
    {
        onTriggerAttackPlayerEvent.OnRaiseEvent -= PlayAttackAnimation;
        onPlayerKilledEvent.OnRaiseEvent -= PlayDeadAnimation;
    }
}
