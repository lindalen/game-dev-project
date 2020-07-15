using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    public Vector3 GetPosition()
    {
        return position;
    }
    //TODO: create method for getting this waypoints position + random small margin
}
