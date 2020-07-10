using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    // Cached variables for UI elements
    [SerializeField] private Text targetsClickedText;
    [SerializeField] private Text fastestClickText;
    [SerializeField] private Text levelReachedText;
    [SerializeField] private GameObject canvasObject;
    private Canvas gameCanvas;

    private void Start()
    {
        gameCanvas = canvasObject.GetComponent<Canvas>(); // should only be one canvas
    }

    // Canvas methods
    public void EnableCanvas()
    {
        gameCanvas.enabled = true;
    }

    public void DisableCanvas()
    {
        gameCanvas.enabled = false;
    }

    // Targets clicked text methods
    public void UpdateTargetsClickedText(int targetsClicked)
    {
        targetsClickedText.color = Color.black;
        targetsClickedText.text = "Targets clicked: " + targetsClicked;
    }

    public void UpdateTargetsClickedTextWithRecord(int targetsClicked)
    {
        targetsClickedText.color = Color.green;
        targetsClickedText.text = "Targets clicked: " + targetsClicked + "(NEW RECORD!)";
    }

    // Fastest click text methods
    public void UpdateFastestClickText(float fastestClickTime)
    {
        fastestClickText.color = Color.black;
        fastestClickText.text = "Fastest click: " + fastestClickTime.ToString("F2");
    }

    public void UpdateFastestClickTextWithRecord(float fastestClickTime)
    {
        fastestClickText.color = Color.green;
        fastestClickText.text = "Fastest click: " + fastestClickTime.ToString("F2") + "(NEW RECORD!)";
    }

    // Level reached text methods
    public void UpdateLevelReachedText(int level)
    {
        levelReachedText.color = Color.black;
        levelReachedText.text = "Level reached: " + level;
    }

    public void UpdateLevelReachedTextWithRecord(int level)
    {
        levelReachedText.color = Color.green;
        levelReachedText.text = "Level reached: " + level + "(NEW RECORD!)";
    }
}
