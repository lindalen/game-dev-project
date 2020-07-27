using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementController : MonoBehaviour
{
    private InstantiatePrefabAtLocation instantiator;
    private TowerPositionValidator validator;

    // Start is called before the first frame update
    void Awake()
    {
        instantiator = GetComponent<InstantiatePrefabAtLocation>();
        validator = GetComponent<TowerPositionValidator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Mouse click detected");
            if (validator.GetIsValidPosition())
            {
                instantiator.PlaceObjectAtCurrentLocation();
                //DestroySpriteBecauseTowerHasBeenPlaced()
            } else
            {
                Debug.Log("Mouse click detected, but location invalid");
            }
        }
    }

    private void DestroySpriteBecauseTowerHasBeenPlaced()
    {
        Destroy(gameObject);
    }
}
