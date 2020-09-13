using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] FloatVariable playerCurrentHealth;
    [SerializeField] FloatVariable playerMaxHealth;

    [SerializeField] GameObject healerGO;
    [SerializeField] GameObject attackerGO;
    [SerializeField] GameObject defenderGO;

    private Attacker attacker;
    private HealthIncreaser healer;
    private Defender defender;



    void Awake()
    {
        attacker = attackerGO.GetComponent<Attacker>();
        healer = healerGO.GetComponent<HealthIncreaser>();
        defender = defenderGO.GetComponent<Defender>();
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
    }

    public void InitPlayer()
    {
        playerCurrentHealth.RuntimeValue = playerMaxHealth.RuntimeValue; //full hp at start of encounter
        attacker.SetActive(true);
        defender.SetActive(true);
        healer.SetActive(true);
    }

    private void DeathCheck()
    {
        if (playerCurrentHealth.RuntimeValue > 0) return;
        StopPlayer();
    }

    public void StopPlayer()
    {
        attacker.SetActive(false);
        defender.SetActive(false);
        healer.SetActive(false);
    }
}
