using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float secsUntilDestruction;

    private float lifeTime;

    void Start()
    {
        secsUntilDestruction = 0.5f;
        lifeTime = Time.time + secsUntilDestruction;
    }

    void Update()
    {
        LifeCycle();
    }

    void LifeCycle()
    {
        if (lifeTime > Time.time) return;
        DestroySelf();

    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    //TODO: Add function that destroys self, but first registers successful click
}
