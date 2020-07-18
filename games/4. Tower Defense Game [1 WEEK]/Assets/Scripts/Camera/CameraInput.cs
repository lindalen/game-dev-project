using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
    private float _horizontalDirection;
    public float HorizontalDirection
    {
        get { return _horizontalDirection; }
        private set { _horizontalDirection = value; }
    }

    private void Awake()
    {
        _horizontalDirection = 0;
    }

    void Update()
    {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");
    }
}
