using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity, IDamageable
{
    [Header("Status")]
    [SerializeField] private bool isDead;
    public float maxHealtPoint;
    [SerializeField] private bool isPickUpCard;

    public string nameCharacter;
    public float healtPoints {  get; set; }
    public float dealDamage;

    public virtual void DealDamage(Character target)
    {
        Debug.Log("Dealing damage");
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("TakeDamage called with: " + damage);
        healtPoints -= damage;
        if (healtPoints <= 0)
        {
            Debug.Log($"{nameCharacter} is dead!");
            isDead = true;
            OnDeath();
        }
    }
    
    public bool GetIsDeadCharacter()
    {
        return isDead;
    }

    public virtual void OnDeath()
    {

    }
}
