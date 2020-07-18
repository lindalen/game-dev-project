using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject backgroundGO;

    private CameraBounds camBounds;
    private CameraInput camInput;

    // idea: bool for freezing movement here could be good

    private void Awake()
    {
        camBounds = GetComponent<CameraBounds>();
        camInput = GetComponent<CameraInput>();
        camBounds.Init(backgroundGO.GetComponent<SpriteRenderer>().sprite.bounds.size.x);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalDirection = camInput.HorizontalDirection;
        float moveForce = horizontalDirection * moveSpeed;
        Vector3 newPosition = camBounds.GetNewPositionWithinBounds(transform.position, moveForce);
        transform.position = newPosition;
    }
}


