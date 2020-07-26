using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Component 
    GetHorizontalInput horizontalInput;
    CameraMovementLimiter camLimiter;

    private float horizontalInputValue;
    private float xLimit;

    private void Awake()
    {
        horizontalInput = GetComponent<GetHorizontalInput>();
        camLimiter = GetComponent<CameraMovementLimiter>();
        xLimit = camLimiter.GetXLimit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        horizontalInputValue = horizontalInput.GetInput();
        if (horizontalInputValue!=0) MoveCamera(horizontalInputValue);
    }

    private void MoveCamera(float horizontalInputValue)
    {
        float xMovement = moveSpeed * horizontalInputValue;
        Vector3 newPosition = transform.position + new Vector3(xMovement, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, -xLimit, xLimit);
        // clamp x movement
        Camera.main.transform.position = newPosition;
    }
}
