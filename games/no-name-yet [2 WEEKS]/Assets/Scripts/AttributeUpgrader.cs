using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeUpgrader : MonoBehaviour
{
    [SerializeField] FloatVariable attributeValue;
    [SerializeField] FloatVariable attributeFrequency;
    [SerializeField] FloatVariable playerGold;

    [SerializeField] float baseCost;
    [SerializeField] float costIncreaseMultiplier;
    [SerializeField] float upgradeValueMultiplier;
    [SerializeField] float upgradeFreqMultiplier;

    private int timesUpgraded;

    private DisplayAttributeStats displayer;

    void Awake()
    {
        displayer = GetComponent<DisplayAttributeStats>();
        timesUpgraded = 0;
        UpgradeAttributeFromTimesUpgraded();
        displayer.UpdateText(baseCost, attributeValue.RuntimeValue, attributeFrequency.RuntimeValue);
    }

    
    private void UpgradeAttributeFromTimesUpgraded()
    {
        for (int i=0; i<timesUpgraded; i++)
        {
            attributeValue.RuntimeValue *= upgradeValueMultiplier;
            attributeFrequency.RuntimeValue *= upgradeFreqMultiplier;
            baseCost *= costIncreaseMultiplier;
        }
    }

    public void UpgradeAttribute()
    {
        if (playerGold.RuntimeValue >= baseCost)
        {
            Upgrade();
        }
    }

    private void Upgrade()
    {
        playerGold.RuntimeValue -= baseCost;
        attributeValue.RuntimeValue *= upgradeValueMultiplier;
        attributeFrequency.RuntimeValue *= upgradeFreqMultiplier;
        baseCost *= costIncreaseMultiplier;
        timesUpgraded++;
        displayer.UpdateText(baseCost, attributeValue.RuntimeValue, attributeFrequency.RuntimeValue);
    }

}
