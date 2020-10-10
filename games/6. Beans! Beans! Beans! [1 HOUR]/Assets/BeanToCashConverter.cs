using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanToCashConverter : MonoBehaviour
{
    [SerializeField] FloatVariable totalBeans;
    [SerializeField] FloatVariable totalCash;

    [SerializeField] float beanToCashRatio;

    public void SellAllBeans()
    {
        totalCash.RuntimeValue += totalBeans.RuntimeValue * beanToCashRatio;
        totalBeans.RuntimeValue = 0;
    }
}
