using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public List<GameObject> waypoints;
    private List<Vector3> waypointPositions;

    private void Awake()
    {
        waypointPositions = new List<Vector3>();
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

    public List<Vector3> GetWaypoints()
    {
        return waypointPositions;
    }
}
