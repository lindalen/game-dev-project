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

    public void GoToNextStage()
    {
        currentStage.RuntimeValue++;
        gameLoopManager.ResetCombat();
        enemyStrengthManager.UpdateEnemyStrength();
    }

    public void GoToPreviousStage()
    {
        if (currentStage.RuntimeValue <=1) return;
        currentStage.RuntimeValue--;
        enemyStrengthManager.UpdateEnemyStrength();
        gameLoopManager.ResetCombat();

    }
    private void EnsurePositiveStage()
    {
        if (currentStage.RuntimeValue < 1) currentStage.RuntimeValue = 1;
    }

    public int GetCurrentStageNumber()
    {
        return currentStage.RuntimeValue;
    }
}
