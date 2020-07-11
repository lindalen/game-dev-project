using System.Collections;
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
    private float targetRadius;
    private Vector2 lastTargetPosition;

    // Animation stuff
    private float handLingerTime;
    private SpriteRenderer handSR;

    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject longHandPrefab;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private UIUpdater uiUpdater;
    [SerializeField] private AudioPlayer audioPlayer;



    void Awake()
    {
        InitializeVariablesForNewSession();
    }

    private void Start()
    {
        Camera cam = Camera.main;
        xBounds = cam.aspect * cam.orthographicSize;
        yBounds = cam.orthographicSize;
        targetRadius = targetPrefab.GetComponent<CircleCollider2D>().radius;
        audioPlayer = AudioPlayer.instance;
        margin = targetRadius * 2; // must be done here since it uses value initialized in start method
        uiUpdater = FindObjectOfType<UIUpdater>();
        handSR = longHandPrefab.GetComponent<SpriteRenderer>();
        SpawnTarget(); // not optimal but logic is ok
    }

    public void ResetAndStartSpawner()
    {
        InitializeVariablesForNewSession();
        SpawnTarget();
    }
    private void InitializeVariablesForNewSession()
    {
        secondsUntilDestruction = 2f;
        percentLessSecondsPerSpawn = 0.90f;
        fastestClickTime = 999f;
        targetsSpawned = 0;
        lastSpawnTime = Time.time;
        level = 1;
        targetsClickedThisLevel = 0;
        targetsPerLevel = 10;
        handLingerTime = 0.1f;
    }

    private void SpawnTarget()
    {
        // gets a new random position within screen
        Vector2 randomPosition = GetRandomPositionWithinScreen();
        // stores this location as location of last spawned target
        lastTargetPosition = randomPosition;
        // instantiates target prefab in random position
        GameObject nextTarget = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        // initializes variable secsUntilDestruction in the newly spawned target
        nextTarget.SendMessage("Init", secondsUntilDestruction);
    }

    private void OnTargetClicked()
    {
        // checks and updates fastest click time if last target was clicked faster than previous record
        UpdateFastestClickTime();
        // plays coin grab sound
        audioPlayer.PlaySound("Coin_grab");
        // animates a hand that grabs the coin
        HandAnimation();
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
        EnemyHandAnimation();
        PlayEnemyGrabSound();
    }
    private void PlayEnemyGrabSound()
    {
        audioPlayer.PlaySound("Coin_enemy_grab");
    }
    private void SetLastSpawnTime()
    {
        lastSpawnTime = Time.time;
    }

    public int GetTargetsClicked()
    {
<<<<<<< Updated upstream
        if (targetsSpawned!=0) return targetsSpawned - 1;
=======
>>>>>>> Stashed changes
        return targetsSpawned;
    }

    public float GetFastestClickTime()
    {
        if (fastestClickTime < 500) return fastestClickTime; 
        return 0;
    }

    public int GetLevel()
    {
        return level;
    }

    private void HandAnimation()
    {
        if (handSR.flipY) handSR.flipY = false; // resets hand
        GameObject hand = Instantiate(longHandPrefab, lastTargetPosition -= new Vector2(0, 2), Quaternion.identity);
        Destroy(hand, handLingerTime);
    }

    private void EnemyHandAnimation()
    {
        handSR.flipY = true;
        GameObject hand = Instantiate(longHandPrefab, lastTargetPosition -= new Vector2(0, -2), Quaternion.identity);
        Destroy(hand, handLingerTime+0.5f);
    }
}
