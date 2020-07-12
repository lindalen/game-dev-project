using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] TargetSpawner spawner;
    private float secsUntilDestruction;

    private float lifeTime;
    private bool isLifetimeIntialized;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        isLifetimeIntialized = false;
    }
    void Start()
    {
        spawner = FindObjectOfType<TargetSpawner>();
    }
    public void Init(float secsUntilDestruction)
    {
        this.secsUntilDestruction = secsUntilDestruction;
        lifeTime = Time.time + secsUntilDestruction;
        isLifetimeIntialized = true;
    }
    void Update()
    {
        if (!isLifetimeIntialized) return;
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
        SendTargetClickedMessage(); // tells spawner that this target was successfully clicked
        DestroySelf();
    }


    private void SendTargetNotClickedMessage()
    {
        spawner.SendMessage("StopSpawning");
    }

    private void SendTargetClickedMessage()
    {
        spawner.SendMessage("OnTargetClicked");
    }
}
