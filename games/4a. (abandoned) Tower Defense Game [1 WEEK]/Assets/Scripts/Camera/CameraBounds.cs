using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private float leftBound;
    private float rightBound;

    private bool hasBeenInitialized;

    public void Init(float backgroundBoundsSize)
    {
        Camera cam = Camera.main;
        float horizontalCameraReach = cam.orthographicSize * (cam.aspect);
        rightBound = backgroundBoundsSize - horizontalCameraReach;
        leftBound = horizontalCameraReach - backgroundBoundsSize;
        hasBeenInitialized = true;
    }

    public bool GetInitBool()
    {
        return hasBeenInitialized;
    }

    public Vector3 GetNewPositionWithinBounds(Vector3 startPosition, float changeInX)
    {
        Vector3 newPosition = startPosition + new Vector3(changeInX, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);
        return newPosition;
    }
}
