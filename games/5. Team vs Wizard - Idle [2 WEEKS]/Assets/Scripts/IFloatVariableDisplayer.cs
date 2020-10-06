using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IFloatVariableDisplayer : MonoBehaviour
{
    [SerializeField] Text textBox;
    [SerializeField] FloatVariable floatVariable;

    BigNumberFormatter formatter;

    void Awake()
    {
        formatter = GetComponent<BigNumberFormatter>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = formatter.GetFormattedNumber(floatVariable.RuntimeValue);
    }

}
