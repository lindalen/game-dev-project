using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject backgroundGO;
    private CameraBounds camBounds;


    private float leftBound;
    private float rightBound;
    // idea: bool for freezing movement here could be good

    private void Awake()
    {
        camBounds = new CameraBounds();
        camBounds.Init(backgroundGO.GetComponent<SpriteRenderer>().sprite.bounds.size.x);

        if (camBounds.GetInitBool())
        {
            leftBound = camBounds.GetLeftBound();
            rightBound = camBounds.GetRightBound();
        } else
        {
            Debug.LogError("CameraBounds not initialized");
        }
        //Debug.Log(backgroundGO.GetComponent<SpriteRenderer>().sprite.bounds.size);
        //Debug.Log(Camera.main.orthographicSize * (Camera.main.aspect));
        Debug.Log("Clamping camera x-axis between: " + leftBound + " and " + rightBound);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        float moveForce = direction * moveSpeed;
        Vector3 newPosition = transform.position + new Vector3(moveForce, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);
        transform.position = newPosition;
    }
}

internal class CameraBounds
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
    public float GetLeftBound()
    {
        return leftBound;
    }

    public float GetRightBound()
    {
        return rightBound;
    }
}
