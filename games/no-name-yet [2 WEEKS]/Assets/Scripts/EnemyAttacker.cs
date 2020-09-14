using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] FloatVariable enemyDMG;
    [SerializeField] FloatVariable enemyAttackFreq;
    [SerializeField] FloatVariable targetHealth;

    private bool active;
    private float lastAttackTime;

    private void Awake()
    {
        active = false;
        lastAttackTime = Time.time;
    }
    // todo: add scriptableboject for player damage reduction
    // todo: any change to the player health is multiplied by damagereduction
    private void Update()
    {
        if (!active) return;
        Attack();
    }

    private void Attack()
    {
        if (Time.time < lastAttackTime + (1 / enemyAttackFreq.RuntimeValue)) return;
        targetHealth.RuntimeValue -= enemyDMG.RuntimeValue;
        lastAttackTime = Time.time;
    }
    public void SetActive(bool b)
    {
        active = b;
    }

    public void SetEnemyDamage(float n)
    {
        enemyDMG.RuntimeValue = n;
    }

    public void SetEnemyAttackFreq(float n)
    {
        enemyAttackFreq.RuntimeValue = n;
    }
}
