using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject waveController;

    [SerializeField] private float StartGameWaitTime;

    // Components
    private WaveManager waveManager;

    void Awake()
    {
        waveManager = waveController.GetComponent<WaveManager>();

        StartGameWaitTime = 2f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("StartGameLoop", StartGameWaitTime);
    }


    private void StartGameLoop()
    {
        StartCoroutine(waveManager.StartSpawning());
    }

    
}
