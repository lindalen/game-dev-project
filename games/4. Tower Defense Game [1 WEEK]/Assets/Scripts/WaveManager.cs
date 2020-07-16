using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] public GameObject crawlerPrefab;
    [SerializeField] private GameObject demonPrefab;
    // Components
    private EnemySpawner spawner;

    // Fields
    private int currentWaveNumber;

    // Start is called before the first frame update
    void Awake()
    {
        spawner = GetComponent<EnemySpawner>();

        currentWaveNumber = 0;
    }

    void Start()
    {
        SpawnWave();
    }

    public void SpawnWave()
    {
        var currentWave = waves[currentWaveNumber];

        float spawnRate = currentWave.spawnRate;

        int crawlersToSpawn = currentWave.crawlerCount;
        int demonsToSpawn = currentWave.demonCount;

        StartCoroutine(SpawnCrawlersInWave(crawlersToSpawn, spawnRate));
        StartCoroutine(SpawnDemonsInWave(demonsToSpawn, spawnRate));
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
