using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHarvest : MonoBehaviour
{
    [SerializeField] FloatVariable beansPerSec;
    [SerializeField] FloatVariable totalBeans;

    void Start()
    {
        InvokeRepeating("Harvest", 1f, 1f);
    }

    void Harvest()
    {
        totalBeans.RuntimeValue += beansPerSec.RuntimeValue;
    }
}
