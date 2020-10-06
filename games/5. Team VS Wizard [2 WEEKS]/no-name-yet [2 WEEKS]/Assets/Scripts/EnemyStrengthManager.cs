using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrengthManager : MonoBehaviour
{
    private StageManager stageManager;

    [SerializeField] GameObject enemyGO;
    private EnemyManager enemyManager;
    private EnemyAttacker enemyAttacker;

    [SerializeField] float dmgIncreaseByStageMultiplier;
    [SerializeField] float atkSpeedIncreaseByStageMultiplier;
    [SerializeField] float healthIncreaseByStageMulitplier;
    [SerializeField] float goldRewardIncreaseByStageMultiplier;
    [SerializeField] float expRewardIncreaseByStageMultiplier;

    [SerializeField] FloatVariable BASE_enemyHP;
    [SerializeField] FloatVariable BASE_enemyDMG;
    [SerializeField] FloatVariable BASE_enemyAttackFreq;
    [SerializeField] FloatVariable BASE_enemyGoldReward;
    [SerializeField] FloatVariable BASE_enemyExpReward;

    void Awake()
    {
        stageManager = GetComponent<StageManager>();
        enemyAttacker = enemyGO.GetComponent<EnemyAttacker>();
        enemyManager = enemyGO.GetComponent<EnemyManager>();
    }

    public void UpdateEnemyStrength()
    {
        // Gets current stage number
        int currentStage = stageManager.GetCurrentStageNumber();

        // Updates HP
        enemyManager.SetEnemyHP(GetValueByStage(BASE_enemyHP.RuntimeValue, healthIncreaseByStageMulitplier, currentStage));
        // Updates exp reward
        enemyManager.SetCurrentExpReward(GetValueByStage(BASE_enemyExpReward.RuntimeValue, expRewardIncreaseByStageMultiplier, currentStage));
        // Updates gold reward
        enemyManager.SetCurrentGoldReward(GetValueByStage(BASE_enemyGoldReward.RuntimeValue, goldRewardIncreaseByStageMultiplier, currentStage));
        // Updates damage
        enemyAttacker.SetEnemyDamage(GetValueByStage(BASE_enemyDMG.RuntimeValue, dmgIncreaseByStageMultiplier, currentStage));
        // Updates atk speed
        enemyAttacker.SetEnemyAttackFreq(GetValueByStage(BASE_enemyAttackFreq.RuntimeValue, atkSpeedIncreaseByStageMultiplier, currentStage));
    }

    private float GetValueByStage(float baseValue, float multiplier, int stageNumber)
    {
        return baseValue * (Mathf.Pow(multiplier, stageNumber));
    }
}
