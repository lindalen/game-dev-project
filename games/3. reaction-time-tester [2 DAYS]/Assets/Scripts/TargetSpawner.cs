using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    private float secondsUntilDestruction;
    private float percentLessSecondsPerSpawn;
    private float bestTime;

    private float margin;
    private float xBounds;
    private float yBounds;

    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private Text bestTimeText;

    void Start()
    {
        secondsUntilDestruction = 2f;
        percentLessSecondsPerSpawn = 0.95f;
        bestTime = secondsUntilDestruction;

        margin = 0.5f; // magic number, should be 1/2*sprite radius to ensure visibility

        Camera cam = Camera.main;
        xBounds = cam.aspect * cam.orthographicSize;
        yBounds = cam.orthographicSize;

        SpawnNextTarget();
    }

    private void SpawnNextTarget()
    {
        // call method to get a new random position within screen
        Vector2 randomPosition = GetRandomPositionWithinScreen();
        // call method to instantiate target prefab within
        GameObject nextTarget = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        // call method to initialize variable secsUntilDestruction
        nextTarget.SendMessage("Init", secondsUntilDestruction);
        // call method to reduce secsUntilDestruction
        ReduceSecondsUntilDestruction();
        // call method to update UI text for best time
        UpdateBestTime();
    }

    private void ReduceSecondsUntilDestruction()
    {
        secondsUntilDestruction *= percentLessSecondsPerSpawn;
        Debug.Log(secondsUntilDestruction);
    }

    private Vector2 GetRandomPositionWithinScreen()
    {
        float x = Random.Range(-xBounds+margin, xBounds-margin);
        float y = Random.Range(-yBounds+margin, yBounds-margin);
        return new Vector2(x, y);
    }

    private void StopSpawning()
    {
        gameManager.SendMessage("GameOver");
        UpdateBestTime();
    }

    private void UpdateBestTime()
    {
        bestTimeText.text = "Best time: " + secondsUntilDestruction.ToString("F2");
    }
}
