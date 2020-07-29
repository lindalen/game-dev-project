using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveConfig[] waveConfigs;
    
    [SerializeField] private float secondsBetweenWaves;

    private bool lastWaveFinishedSpawning;
    private EnemySpawner spawner;
    private WaveUIUpdater uiUpdater;

    void Awake()
    {
        spawner = GetComponent<EnemySpawner>();
        uiUpdater = GetComponent<WaveUIUpdater>();
    }

    public void StartWaveManager()
    {
        StartCoroutine(StartWaveSpawning());
    }

    private IEnumerator SpawnWave(WaveConfig wave)
    {
        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            spawner.SpawnEnemy();
            
            yield return new WaitForSeconds(1/wave.enemiesPerSecond);
        }
        lastWaveFinishedSpawning = true;
    }

    private IEnumerator StartWaveSpawning()
    {
        foreach (WaveConfig wave in waveConfigs)
        {
            uiUpdater.DisplayCurrentWave(wave.waveNumber);
            StartCoroutine(SpawnWave(wave));
            while(!lastWaveFinishedSpawning)
            {
                yield return null;
            }
            uiUpdater.DisplayWaveCooldown(Time.time + secondsBetweenWaves);
            yield return new WaitForSeconds(secondsBetweenWaves);
        }
        ResourceController.Instance.DisplayGameOverScreen();
    }


}
