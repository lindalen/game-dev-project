using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenerator
{
    float currencyPerSecond { get; set; }
    float upgradeMultiplier { get; set; }

    void GenerateCurrency();

}
