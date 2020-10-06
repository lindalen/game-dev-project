using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntVariableDisplayer : MonoBehaviour
{
    [SerializeField] Text textBox;
    [SerializeField] IntVariable intVariable;


    void Update()
    {
        textBox.text = "Stage: "+intVariable.RuntimeValue;
    }

}
