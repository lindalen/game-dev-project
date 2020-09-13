using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNumberFormatter : MonoBehaviour
{
    public string GetFormattedNumber(float value)
    {
        return Format(value);
    }
    private string Format(float value)
    {
        string s = "";
        float currentValue = value;
        float conditional = Mathf.Log10(value);

        int thousandLimit = 3;
        int millionLimit = 6;
        int billionLimit = 9;

        if (conditional < thousandLimit)
        {
            s = currentValue.ToString("F1");
        }
        else if (conditional >= thousandLimit && conditional < millionLimit)
        {
            s = (currentValue / Mathf.Pow(10, thousandLimit)).ToString("F1") + "K";
        }
        else if (conditional >= millionLimit && conditional < billionLimit)
        {
            s = (currentValue / Mathf.Pow(10, millionLimit)).ToString("F1") + "M";
        }
        else
        {
            s = (currentValue / Mathf.Pow(10, billionLimit)).ToString("F1") + "B";
        }

        return s;
    }
}
