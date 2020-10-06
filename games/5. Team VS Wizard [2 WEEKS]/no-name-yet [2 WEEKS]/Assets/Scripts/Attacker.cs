using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] FloatVariable attackDMG;
    [SerializeField] FloatVariable attackFreq;
    [SerializeField] FloatVariable targetHealth;

    private SingleAnimationController animController;
    private Animator animator;

    float lastAttackTime;
    private bool active = false;

    void Awake()
    {
        animController = GetComponent<SingleAnimationController>();
        animator = GetComponent<Animator>();
        lastAttackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;
        AttackLoop();
    }

    private void AttackLoop()
    {
        if (Time.time < lastAttackTime + (1 / attackFreq.RuntimeValue)) return;

        Attack();
    }
    private void Attack()
    {
        targetHealth.RuntimeValue -= attackDMG.RuntimeValue;
        animator.SetTrigger("Attack");
        lastAttackTime = Time.time;
    }

    public void SetActive(bool b)
    {
        active = b;
    }
}
