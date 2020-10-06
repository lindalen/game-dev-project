using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] FloatVariable enemyDMG;
    [SerializeField] FloatVariable enemyAttackFreq;
    [SerializeField] FloatVariable targetHealth;
    [SerializeField] GameObject targetGO;

    private bool active;
    private float lastAttackTime;
    private PlayerManager playerManager;
    private Animator animator;

    private void Awake()
    {
        playerManager = targetGO.GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
        active = false;
        lastAttackTime = Time.time;
    }

    private void Update()
    {
        if (!active) return;
        Attack();
    }

    private void Attack()
    {
        if (Time.time < lastAttackTime + (1 / enemyAttackFreq.RuntimeValue)) return;
        float totalAttackDamage = enemyDMG.RuntimeValue * playerManager.GetCurrentDamageReduction();
        animator.SetTrigger("Attack");
        targetHealth.RuntimeValue -= totalAttackDamage;
        
        //Debug.Log("Attaking with DMG: " + enemyDMG.RuntimeValue + ", DMGRED: " + playerManager.GetCurrentDamageReduction() + ", ACTDMG: " + totalAttackDamage);
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
