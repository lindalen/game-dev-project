using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    [SerializeField] GameObject enemyGO;

    

    private PlayerManager playerManager;
    private EnemyManager enemyManager;

    void Awake()
    {
        playerManager = playerGO.GetComponent<PlayerManager>();
        enemyManager = enemyGO.GetComponent<EnemyManager>();
    }

    void Update()
    {
        GameLoop();
    }

    private void GameLoop()
    {
        if (playerManager.GetCurrentHP() <= 0)
        {
            ResetCombat();
        }

        if (enemyManager.GetCurrentHP() <= 0)
        {
            RewardPlayerOnEnemyKill();
            ResetCombat();
        }
    }

    public void ResetCombat()
    {
        playerManager.StopPlayer();
        enemyManager.StopEnemy();

        playerManager.FullyHeal();
        enemyManager.FullyHeal();

        playerManager.InitPlayer();
        enemyManager.InitEnemy();
    }

    private void RewardPlayerOnEnemyKill()
    {
        playerManager.AddGold(enemyManager.GetReward());
        playerManager.AddExp(enemyManager.GetExp());
    }
}
