using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHorizontalInput : MonoBehaviour
{
    private float horizontalInput;

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    public float GetInput()
    {
        return horizontalInput;
    }
}
