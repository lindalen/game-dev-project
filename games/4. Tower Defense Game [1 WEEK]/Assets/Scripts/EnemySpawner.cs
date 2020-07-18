using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject topPathPrefab;
    [SerializeField] private GameObject bottomPathPrefab;

    private List<Vector3> topPath;
    private List<Vector3> bottomPath;

    private void Awake()
    {
        topPath = topPathPrefab.GetComponent<Path>().GetWaypoints();
        bottomPath = bottomPathPrefab.GetComponent<Path>().GetWaypoints();
    }

    private List<Vector3> GetRandomPath()
    {
        int diceRoll = Random.Range(0, 100);
        if (diceRoll > 50) return topPath;
        return bottomPath;
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        //todo: check the randompath, something seems funky
        var path = GetRandomPath();
        var enemy = Instantiate(enemyPrefab, path[0]+new Vector3(-1,0,0), Quaternion.identity);

        enemy.GetComponent<EnemyMovement>().SetPathAndStartMoving(path);
    }
    
}
