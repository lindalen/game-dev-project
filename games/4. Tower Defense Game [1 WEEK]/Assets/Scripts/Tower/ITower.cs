using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    TowerConfig Config { get; set; }
    float Damage { get; set; }
    float FireRate { get; set; }
    float Cost { get; set; }
    float AttackRadius { get; set; }

    void DealDamage();
    void DetectEnemiesInRange();
    void SelectEnemy();
}
