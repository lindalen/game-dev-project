using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] FloatVariable attackDMG;
    [SerializeField] FloatVariable attackFreq;
    [SerializeField] FloatVariable targetHealth;

    float lastAttackTime;
    private bool active = false;

    void Awake()
    {
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
        lastAttackTime = Time.time;
    }

    public void SetActive(bool b)
    {
        active = b;
    }
}
