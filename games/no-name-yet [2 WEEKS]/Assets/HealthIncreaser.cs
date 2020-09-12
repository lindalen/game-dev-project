using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncreaser : MonoBehaviour
{
    [SerializeField] FloatVariable health;
    [SerializeField] FloatVariable maxHealth;
    [SerializeField] FloatVariable healFreq;
    [SerializeField] FloatVariable healAmount;

    private float lastHealTime;

    private void Awake()
    {
        lastHealTime = 0;
    }

    private void Update()
    {
        HealLoop();
    }

    void Start()
    {
        //InvokeRepeating("Heal", 0.1f, healFreq.RuntimeValue);
    }
    private void HealLoop()
    {
        if (Time.time < lastHealTime + (1 / healFreq.RuntimeValue)) return;
        Heal();
        lastHealTime = Time.time;
    }
    private void Heal()
    {
        float _healAmount = healAmount.RuntimeValue;
        if (health.RuntimeValue+_healAmount > maxHealth.RuntimeValue) //overheal check
        {
            health.RuntimeValue = maxHealth.RuntimeValue;
        } else
        {
            //Debug.Log("Old health:" + health.RuntimeValue);
            health.RuntimeValue += _healAmount;
            //Debug.Log("New health:" + health.RuntimeValue);
        }
    }
}
