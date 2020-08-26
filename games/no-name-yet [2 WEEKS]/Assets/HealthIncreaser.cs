using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncreaser : MonoBehaviour
{
    [SerializeField] FloatVariable health;
    [SerializeField] FloatVariable maxHealth;
    [SerializeField] FloatVariable healFreq;

    [SerializeField] private float healAmount;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Heal", 0.1f, healFreq.RuntimeValue);
    }

    private void Heal()
    {
        if (health.RuntimeValue+healAmount > maxHealth.RuntimeValue) //overheal check
        {
            health.RuntimeValue = maxHealth.RuntimeValue;
        } else
        {
            Debug.Log("Old health:" + health.RuntimeValue);
            health.RuntimeValue += healAmount;
            Debug.Log("New health:" + health.RuntimeValue);
        }
    }
}
