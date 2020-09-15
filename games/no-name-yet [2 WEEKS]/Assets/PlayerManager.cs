using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] FloatVariable playerCurrentHealth;
    [SerializeField] FloatVariable playerMaxHealth;
    [SerializeField] FloatVariable playerGold;
    [SerializeField] FloatVariable playerExp;
    [SerializeField] FloatVariable playerDamageReduction;

    [SerializeField] GameObject healerGO;
    [SerializeField] GameObject attackerGO;
    [SerializeField] GameObject defenderGO;

    private Attacker attacker;
    private HealthIncreaser healer;
    private Defender defender;

    private float currentDamageReduction;

    void Awake()
    {
        attacker = attackerGO.GetComponent<Attacker>();
        healer = healerGO.GetComponent<HealthIncreaser>();
        defender = defenderGO.GetComponent<Defender>();
        currentDamageReduction = 1;
    }
    
    public void ActivateDamageReduction()
    {
        currentDamageReduction = 1 - playerDamageReduction.RuntimeValue;
    }

    public void DeactivateDamageReduction()
    {
        currentDamageReduction = 1;
    }

    public float GetCurrentDamageReduction()
    {
        return currentDamageReduction;
    }

    public void InitPlayer()
    {
        playerCurrentHealth.RuntimeValue = playerMaxHealth.RuntimeValue; //full hp at start of encounter
        attacker.SetActive(true);
        defender.SetActive(true);
        healer.SetActive(true);
    }

    internal void FullyHeal()
    {
        playerCurrentHealth.RuntimeValue = playerMaxHealth.RuntimeValue;
    }

    /*
private void DeathCheck()
{
   if (playerCurrentHealth.RuntimeValue > 0) return;
   StopPlayer();
} */

    public void StopPlayer()
    {
        attacker.SetActive(false);
        defender.SetActive(false);
        healer.SetActive(false);
    }
    public void AddGold(float value)
    {
        playerGold.RuntimeValue += Mathf.Abs(value);
        Debug.Log("Gold is now: " + playerGold.RuntimeValue);
    }
    public void AddExp(float value)
    {
        playerExp.RuntimeValue += Mathf.Abs(value);
    }
    public float GetCurrentHP()
    {
        return playerCurrentHealth.RuntimeValue;
    }
    public float GetMaxHP()
    {
        return playerMaxHealth.RuntimeValue;
    }
}
