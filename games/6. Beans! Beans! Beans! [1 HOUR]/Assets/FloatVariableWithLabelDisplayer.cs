using UnityEngine;
using UnityEngine.UI;


public class FloatVariableWithLabelDisplayer : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] FloatVariable displayVar;
    [SerializeField] string label;

    BigNumberFormatter formatter;

    // Start is called before the first frame update
    void Awake()
    {
        formatter = GetComponent<BigNumberFormatter>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = label + " " + formatter.GetFormattedNumber(displayVar.RuntimeValue);
    }
}
