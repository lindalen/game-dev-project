using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPositionValidator : MonoBehaviour
{
    [SerializeField] private bool isValidPosition;

    void Awake()
    {
        isValidPosition = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Path") // adding  || col.gameObject.tag == "Tower" doesnt work, because you can leave a trigger within another trigger
        {
            isValidPosition = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Path")
        {
            isValidPosition = true;
        }
        // NOTE: Also needs to check if CHURCH or TOWER colliders are in the way
    }

    public bool GetIsValidPosition()
    {
        return isValidPosition;
    }
}
