using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAttributeOnClick : MonoBehaviour
{
    // FloatVariables
    [SerializeField] private FloatVariable unitToUpgrade;
    [SerializeField] private FloatVariable costIncreaseMultiplier;
    [SerializeField] private FloatVariable unitToSpend;

    [SerializeField] private float baseCost;

    private DisplayAttributeStats uiManager;

    private float currentCost;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
