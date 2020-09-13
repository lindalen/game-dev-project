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

    private bool active = false;

    private void Awake()
    {
        lastHealTime = 0;
    }

    private void Update()
    {
        if (!active) return;
        HealLoop();
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

    public void SetActive(bool b)
    {
        active = b;
    }
}
