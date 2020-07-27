using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabAtLocation : MonoBehaviour
{
    [SerializeField] private GameObject prefabToPlace;

    public void PlaceObjectAtCurrentLocation()
    {
        Instantiate(prefabToPlace, transform.position, Quaternion.identity);
    }
}
