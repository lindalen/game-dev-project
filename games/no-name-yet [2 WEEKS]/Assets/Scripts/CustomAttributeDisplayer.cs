using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomAttributeDisplayer : MonoBehaviour
{
    [SerializeField] Text displayText;
    [SerializeField] string labelText;
    [SerializeField] FloatVariable attribute; //bad to limit class to only this type, name should be customfloatvariabledisplayer in that case

    public void Display(string s)
    {
        displayText.text = labelText + s;
    }

    private void FixedUpdate()
    {
        displayText.text = labelText + attribute.RuntimeValue.ToString("F2");
    }
}
