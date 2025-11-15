using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    float healtPoints { get; set; }
    public void TakeDamage(float damage);
}
