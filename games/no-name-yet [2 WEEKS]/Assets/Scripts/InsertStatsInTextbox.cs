using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertStatsInTextbox : MonoBehaviour
{
    [SerializeField] Text textBox;
    [SerializeField] FloatVariable[] variables;
    // Start is called before the first frame update
    void Start()
    {
        ShowAllStats();
    }

    void ShowAllStats()
    {
        foreach (FloatVariable variable in variables)
        {
            textBox.text += variable.name + ": " + variable.RuntimeValue + "\n"; 
        }
    }
}
