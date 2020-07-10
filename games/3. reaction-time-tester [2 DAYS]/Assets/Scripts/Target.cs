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
        if (isLifetimeIntialized) LifeCycle();
    }

    void LifeCycle()
    {
        if (lifeTime > Time.time) return;
        Debug.Log("Lifetime: " + lifeTime + " , Time now: " + Time.time);
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
        Debug.Log("Clicking target failed, sending game over message");
        spawner.SendMessage("StopSpawning");
    }

    private void SendTargetClickedMessage()
    {
        spawner.SendMessage("OnTargetClicked");
    }
}
