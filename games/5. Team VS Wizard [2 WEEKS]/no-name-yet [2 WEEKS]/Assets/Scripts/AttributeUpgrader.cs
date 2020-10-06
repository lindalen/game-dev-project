using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeUpgrader : MonoBehaviour
{
    [SerializeField] FloatVariable mainAttribute;
    [SerializeField] FloatVariable attributeCharacteristic;
    [SerializeField] FloatVariable playerGold;
    [SerializeField] FloatVariable baseCost;

    [SerializeField] float costIncreaseMultiplier;
    [SerializeField] float upgradeValueMultiplier;
    [SerializeField] float upgradeFreqMultiplier;

    private int timesUpgraded;

    private CustomAttributeDisplayer mainDisplayer;
    private CustomAttributeDisplayer sideDisplayer;

    void Awake()
    {
        timesUpgraded = 0;
        UpgradeAttributeFromTimesUpgraded();
    }

    
    private void UpgradeAttributeFromTimesUpgraded()
    {
        for (int i=0; i<timesUpgraded; i++)
        {
            mainAttribute.RuntimeValue *= upgradeValueMultiplier;
            attributeCharacteristic.RuntimeValue *= upgradeFreqMultiplier;
            baseCost.RuntimeValue *= costIncreaseMultiplier;
        }
    }

    public void UpgradeAttribute()
    {
        if (playerGold.RuntimeValue >= baseCost.RuntimeValue)
        {
            Upgrade();
        }
    }

    private void Upgrade()
    {
        playerGold.RuntimeValue -= baseCost.RuntimeValue;
        mainAttribute.RuntimeValue *= upgradeValueMultiplier;
        attributeCharacteristic.RuntimeValue *= upgradeFreqMultiplier;
        baseCost.RuntimeValue *= costIncreaseMultiplier;
        timesUpgraded++;
    }


}
