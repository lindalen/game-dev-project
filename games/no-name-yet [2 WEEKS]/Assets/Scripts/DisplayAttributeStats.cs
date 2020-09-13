using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAttributeStats : MonoBehaviour
{
    [SerializeField] Text upgradeCostText;
    [SerializeField] Text currentValueText;
    [SerializeField] Text currentValuePerSecondText;

    public void UpdateText(float cost, float current, float persec)
    {
        upgradeCostText.text = "Cost: " + cost;
        currentValueText.text = "Value: " + current;
        currentValuePerSecondText.text = persec + " times/s";
    }
}
