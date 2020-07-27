using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementLimiter : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab;

    private float backgroundSpriteLength;
    private float cameraHorizontalWidthFromCenter;

    private float xLimit;
    // Start is called before the first frame update
    void Awake()
    {
        backgroundSpriteLength = backgroundPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        Camera cam = Camera.main;
        cameraHorizontalWidthFromCenter = cam.aspect * cam.orthographicSize;
        xLimit = backgroundSpriteLength - cameraHorizontalWidthFromCenter;
    }

    public float GetXLimit()
    {
        return xLimit;
    }
}
