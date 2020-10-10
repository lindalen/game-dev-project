using UnityEngine;
using UnityEngine.UI;

public class FloatVariableDisplayer : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] FloatVariable displayVar;

    BigNumberFormatter formatter;

    void Awake()
    {
        formatter = GetComponent<BigNumberFormatter>();
    }


    void Update()
    {
        text.text = formatter.GetFormattedNumber(displayVar.RuntimeValue);
    }
}
