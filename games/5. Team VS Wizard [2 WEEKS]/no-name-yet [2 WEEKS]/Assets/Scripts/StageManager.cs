using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] IntVariable currentStage;

    private EnemyStrengthManager enemyStrengthManager;
    private GameLoopManager gameLoopManager;

    void Awake()
    {
        enemyStrengthManager = GetComponent<EnemyStrengthManager>();
        gameLoopManager = GetComponent<GameLoopManager>();
    }

    private void Start()
    {
        PrepareStageCombat();
    }
    public void GoToNextStage()
    {
        currentStage.RuntimeValue++;
        PrepareStageCombat();


    }

    public void GoToPreviousStage()
    {
        if (currentStage.RuntimeValue <=1) return;
        currentStage.RuntimeValue--;
        PrepareStageCombat();

    }
    private void EnsurePositiveStage()
    {
        if (currentStage.RuntimeValue < 1) currentStage.RuntimeValue = 1;
    }

    public int GetCurrentStageNumber()
    {
        return currentStage.RuntimeValue;
    }

    private void PrepareStageCombat()
    {
        enemyStrengthManager.UpdateEnemyStrength();
        gameLoopManager.ResetCombat();
    }
}
