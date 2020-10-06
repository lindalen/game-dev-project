using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BigNumberFormatter))]
public class BigNumberAttributeDisplayer : MonoBehaviour
{
    [SerializeField] Text displayText;
    [SerializeField] string labelText;
    [SerializeField] FloatVariable attribute;

    BigNumberFormatter formatter;

    public void Display(string s)
    {
        displayText.text = labelText + s;
    }

    private void FixedUpdate()
    {
        displayText.text = labelText + formatter.GetFormattedNumber(attribute.RuntimeValue);
        
    }

    private void Awake()
    {
        formatter = GetComponent<BigNumberFormatter>();
    }
}
