using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] private GameObject prefabToPlace;

    public void PlaceObject(Vector3 mousePosition)
    {
        Instantiate(prefabToPlace, mousePosition, Quaternion.identity);
    }
}
