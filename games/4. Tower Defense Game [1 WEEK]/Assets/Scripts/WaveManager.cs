using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] public GameObject crawlerPrefab;
    [SerializeField] private GameObject demonPrefab;

    // UI elements
    [SerializeField] private Text waveCooldownText;
    [SerializeField] private Text currentWaveText;

    // Components
    private EnemySpawner spawner;

    // Fields
    private int currentWaveNumber;
    private float secsBetweenWaves;

    private bool startTimer;
    private float waveTimeLeft;

    void Awake()
    {
        Debug.Log("WaveManager Awake() called.");
        spawner = GetComponent<EnemySpawner>();
        currentWaveNumber = 0;
        secsBetweenWaves = 10f;
        waveTimeLeft = 0;
    }
    void Update()
    {
        if (Time.time < waveTimeLeft)
        {
            DisplayWaveCooldown(waveTimeLeft - Time.time);
        } 
        //ResetWaveCooldownDisplay();
    }
    public IEnumerator StartSpawning()
    {
        Debug.Log("Spawning started.");
        SpawnWave(currentWaveNumber);

        yield return null;
    }

    private IEnumerator StartCooldownThenSpawnNextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber < waves.Length)
        {
            waveTimeLeft = Time.time + secsBetweenWaves;
            yield return new WaitForSeconds(secsBetweenWaves);
            SpawnWave(currentWaveNumber);
            
        }
        yield return null; // victory game over
    }
    private void DisplayCurrentWave()
    {
        currentWaveText.text = "Wave " + currentWaveNumber+1;
    }

    private void DisplayWaveCooldown(float timeLeft)
    {
        waveCooldownText.text = timeLeft.ToString("F2") + " seconds left until next wave.";
    }

    private void ResetWaveCooldownDisplay()
    {
        waveCooldownText.text = "";
    }

    /*public void StopSpawning()
    {
        //StopCoroutine(SpawnLoop());
    }*/
    public void SpawnWave(int currentWaveNumber)
    {
        Debug.Log("Spawning wave " + currentWaveNumber);
        DisplayCurrentWave();
        var currentWave = waves[currentWaveNumber];

        float spawnRate = currentWave.spawnRate;

        int crawlersToSpawn = currentWave.crawlerCount;
        int demonsToSpawn = currentWave.demonCount;

        StartCoroutine(SpawnCrawlersInWave(crawlersToSpawn, spawnRate));
        StartCoroutine(SpawnDemonsInWave(demonsToSpawn, spawnRate));
        StartCoroutine(StartCooldownThenSpawnNextWave());
    }

    private IEnumerator SpawnCrawlersInWave(int crawlerCount, float spawnRate)
    {
        if (crawlerCount == 0) yield return null;

        for (int i = 0; i < crawlerCount; i++)
        {
            spawner.SpawnEnemy(crawlerPrefab);
            yield return new WaitForSeconds(spawnRate*5);
        }
    }

    private IEnumerator SpawnDemonsInWave(int demonCount, float spawnRate)
    {
        if (demonCount == 0) yield return null;

        for (int i = 0; i < demonCount; i++)
        {
            Debug.Log(demonPrefab);
            spawner.SpawnEnemy(demonPrefab);
            yield return new WaitForSeconds(spawnRate*5);
        }
    }
}
