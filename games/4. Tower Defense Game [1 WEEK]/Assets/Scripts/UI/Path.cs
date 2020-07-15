using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public List<GameObject> waypoints;
    private List<Vector3> waypointPositions;

    private void Start()
    {
        waypointPositions = new List<Vector3>();
        Debug.Log(waypoints.Count);
        InitWaypointList();
    }

    private void InitWaypointList()
    {
        foreach (GameObject go in waypoints)
        {
            // perhaps over the top, but its easier to work with
            waypointPositions.Add(go.transform.position);
        }
    }
}
