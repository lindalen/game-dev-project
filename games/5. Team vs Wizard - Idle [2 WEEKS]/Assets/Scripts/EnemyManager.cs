using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A little monolithic, can be divided
 */
public class EnemyManager : MonoBehaviour
{
    [SerializeField] FloatVariable enemyCurrentHP;
    [SerializeField] FloatVariable enemyMaxHP;

    [SerializeField] FloatVariable enemyCurrentReward;
    [SerializeField] FloatVariable enemyCurrentExpReward;

    private EnemyAttacker attacker;

    void Awake()
    {
        attacker = GetComponent<EnemyAttacker>();
    }

    public void SetEnemyHP(float n)
    {
        enemyMaxHP.RuntimeValue = n;
    }

    public void SetCurrentGoldReward(float n)
    {
        enemyCurrentReward.RuntimeValue = n;
    }

    public void SetCurrentExpReward(float n)
    {
        enemyCurrentExpReward.RuntimeValue = n;
    }

    internal void StopEnemy()
    {
        attacker.SetActive(false);
    }

    internal void FullyHeal()
    {
        enemyCurrentHP.RuntimeValue = enemyMaxHP.RuntimeValue;
    }

    internal void InitEnemy()
    {
        attacker.SetActive(true);
    }

    internal float GetCurrentHP()
    {
        return enemyCurrentHP.RuntimeValue;
    }

    internal float GetReward()
    {
        return enemyCurrentReward.RuntimeValue;
    }

    internal float GetExp()
    {
        return enemyCurrentExpReward.RuntimeValue;
    }
}
