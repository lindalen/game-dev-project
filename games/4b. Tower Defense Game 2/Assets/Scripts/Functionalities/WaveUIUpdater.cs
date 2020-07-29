using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUIUpdater : MonoBehaviour
{
    [SerializeField] private Text currentWaveText;
    [SerializeField] private Text waveCooldownText;

    private bool timerIsRunning;
    private float stopCooldownTime;

    public void DisplayWaveCooldown(float timeToStopCooldown)
    {
        stopCooldownTime = timeToStopCooldown;
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            float secondsLeft = Time.time - stopCooldownTime;
            waveCooldownText.text = "Time until next wave: " + secondsLeft.ToString("F1");

            if (Time.time >= stopCooldownTime)
            {
                waveCooldownText.text = "";
                timerIsRunning = false;
            }
        }
    }

    public void DisplayCurrentWave(int waveNumber)
    {
        currentWaveText.text = "Wave " + waveNumber;
    }
}
