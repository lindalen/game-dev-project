using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] TargetSpawner spawner;
    private float secsUntilDestruction;

    private float lifeTime;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        spawner = FindObjectOfType<TargetSpawner>();
    }
    void Start()
    {
        
        lifeTime = Time.time + secsUntilDestruction;
        
    }
    public void Init(float secsUntilDestruction)
    {
        this.secsUntilDestruction = secsUntilDestruction;
    }
    void Update()
    {
        LifeCycle();
    }

    void LifeCycle()
    {
        if (lifeTime > Time.time) return;
        SendTargetNotClickedMessage();
        DestroySelf();

    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        SendTargetClickedMessage();
        DestroySelf();
    }

    private void UpdateBestReactionTime()
    {

    }

    private void SendTargetNotClickedMessage()
    {
        spawner.SendMessage("StopSpawning");
    }

    private void SendTargetClickedMessage()
    {
        spawner.SendMessage("SpawnNextTarget");
    }
}
