using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatVariableUpgradeOnClick : MonoBehaviour
{
    [SerializeField] float upgradeMultiplier;
    [SerializeField] float costIncreaseMultiplier;

    [SerializeField] float upgradeCost;
    [SerializeField] FloatVariable valueToUpgrade;
    [SerializeField] FloatVariable valueToSpend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        if (valueToSpend.RuntimeValue >= upgradeCost)
        {
            valueToUpgrade.RuntimeValue *= upgradeMultiplier;
            valueToSpend.RuntimeValue -= upgradeCost;
            upgradeCost *= costIncreaseMultiplier;
        }
    }

    public float GetCost()
    {
        return upgradeCost;
    }
}
