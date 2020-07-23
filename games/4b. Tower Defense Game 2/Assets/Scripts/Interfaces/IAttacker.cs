using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    float Damage { get; set; }
    float AttackRadius { get; set; }
    float AttacksPerSecond { get; set; }
    ObjectInRadiusFinder Finder { get; set; }
    ObjectAttacker Attacker { get; set; }

    void DamageEnemies();

}
