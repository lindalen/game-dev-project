using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;
    private int targetsClicked;

    // Stats
    private float bestClickTime;
    private float bestTargetsClicked;
    private int bestLevelReached;

    [SerializeField] private UIUpdater uiUpdater;
    [SerializeField] private TargetSpawner targetSpawner;

    private void Awake()
    {
        InitVariablesForFirstPlaythrough();
    }

    private void Start()
    {
        uiUpdater = FindObjectOfType<UIUpdater>();
        targetSpawner = FindObjectOfType<TargetSpawner>();
        uiUpdater.DisableCanvas();
    }


    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GameOver() called.");
        // Checks if stats from last session are records and updates UI elements accordingly
        RecordCheck();

        // Enables the panel that displays stats and a restart button
        uiUpdater.EnableCanvas();

        Debug.Log("Fastest click: " + bestClickTime);
    }

    private void RestartGame()
    {
        // TODO: make this
        // does the same as Start and Awake, except it keeps records etc
    }
    private void InitVariablesForFirstPlaythrough()
    {
        isGameOver = false;
        bestClickTime = 9999f; // prob not great way to do this
        bestTargetsClicked = 0;
        bestLevelReached = 1;
    }
    private void RecordCheck()
    {
        int targetsClicked = targetSpawner.GetTargetsClicked();
        CheckIfRecordTargetsClicked(targetsClicked);

        float fastestClickTime = targetSpawner.GetFastestClickTime();

        CheckIfRecordClickTime(fastestClickTime);

        int levelReached = targetSpawner.GetLevel();
        CheckIfRecordLevelReached(levelReached);
    }
    private void CheckIfRecordClickTime(float time)
    {
        bool newRecord = time < bestClickTime;

        if (newRecord)
        {
            bestClickTime = time;
            uiUpdater.UpdateFastestClickTextWithRecord(time);
        }
        else
        {
            uiUpdater.UpdateFastestClickText(time);
        }
    }


    private void CheckIfRecordTargetsClicked(int targetsClicked)
    {
        bool newRecord = targetsClicked > bestTargetsClicked;
        
        if (newRecord)
        {
            bestTargetsClicked = targetsClicked;
            uiUpdater.UpdateTargetsClickedTextWithRecord(targetsClicked);
        }
        else
        {
            uiUpdater.UpdateTargetsClickedText(targetsClicked);
        }
    }

    private void CheckIfRecordLevelReached(int levelReached)
    {
        bool newRecord = levelReached > bestLevelReached;

        if (newRecord)
        {
            bestLevelReached = levelReached;
            uiUpdater.UpdateLevelReachedTextWithRecord(levelReached);
        } else
        {
            uiUpdater.UpdateLevelReachedText(levelReached);
        }
    }
}
