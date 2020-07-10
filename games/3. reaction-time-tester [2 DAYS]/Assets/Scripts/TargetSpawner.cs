﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    // Spawning stuff
    private float secondsUntilDestruction;
    private float percentLessSecondsPerSpawn;
    private float lastSpawnTime;

    // Stats
    private float fastestClickTime;
    private int targetsSpawned;

    // Level stuff
    private int level;
    private int targetsPerLevel;
    private int targetsClickedThisLevel;

    // Getting random position within screen stuff
    private float margin;
    private float xBounds;
    private float yBounds;

    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private UIUpdater uiUpdater;


    void Awake()
    {
        secondsUntilDestruction = 2f;
        percentLessSecondsPerSpawn = 0.90f;
        fastestClickTime = 999f;
        targetsSpawned = 0;
        margin = 0.5f; // magic number, should be 1/2*sprite radius to ensure visibility    
        level = 1;
        targetsClickedThisLevel = 0;
        targetsPerLevel = 10;
        // todo: make this a method
    }

    private void Start()
    {
        Camera cam = Camera.main;
        xBounds = cam.aspect * cam.orthographicSize;
        yBounds = cam.orthographicSize;

        uiUpdater = FindObjectOfType<UIUpdater>();
        SpawnTarget();
        // todo: make this a method
    }
    private void SpawnTarget()
    {
        // gets a new random position within screen
        Vector2 randomPosition = GetRandomPositionWithinScreen();
        // instantiates target prefab in random position
        GameObject nextTarget = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        // initializes variable secsUntilDestruction in the newly spawned target
        nextTarget.SendMessage("Init", secondsUntilDestruction);
    }

    private void OnTargetClicked()
    {
        // checks and updates fastest click time if last target was clicked faster than previous record
        UpdateFastestClickTime();
        // increments total targets spawned
        IncrementTargetsSpawned();
        // spawns another target
        SpawnTarget();
        // registers the time the new target was spawned
        SetLastSpawnTime();
        // increment targets clicked since last level change
        IncrementTargetsClickedThisLevel();
        // checks if targets clicked this level = targets per level, if true, increase difficulty
        NextLevelCheck();
    }

    private void NextLevelCheck()
    {
        Debug.Log("Targets clicked this level: " + targetsClickedThisLevel);

        if (targetsClickedThisLevel >= targetsPerLevel)
        {
            targetsClickedThisLevel = 0;
            IncrementCurrentLevel();
            ReduceSecondsUntilDestruction();
        }
    }
    // Probably excessive to make this its own method
    private void IncrementTargetsClickedThisLevel()
    {
        targetsClickedThisLevel++;
    }
    private void IncrementCurrentLevel()
    {
        level++;
    }
    private void IncrementTargetsSpawned()
    {
        targetsSpawned++;
    }

    private void UpdateFastestClickTime()
    {
        float clickTime = Time.time - lastSpawnTime; // gets time since target spawned

        if (FasterClickCheck(clickTime)) fastestClickTime = clickTime;  
    }
    private bool FasterClickCheck(float clickTime)
    {
        return clickTime < fastestClickTime;
    }
    private void ReduceSecondsUntilDestruction()
    {
        secondsUntilDestruction *= percentLessSecondsPerSpawn;
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
    }

    private void SpawnFirstTarget()
    {
        SpawnTarget();
    }

    private void SetLastSpawnTime()
    {
        lastSpawnTime = Time.time;
    }

    public int GetTargetsClicked()
    {
        return targetsSpawned - 1;
    }

    public float GetFastestClickTime()
    {
        return fastestClickTime;
    }

    public int GetLevel()
    {
        Debug.Log("Level reached: " + level);
        return level;
    }
}
