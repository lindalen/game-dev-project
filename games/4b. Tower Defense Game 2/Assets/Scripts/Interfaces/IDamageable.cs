using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float HP { get; set; }

    void OnAttacked(float damage);
    void DeathCheck();
}
