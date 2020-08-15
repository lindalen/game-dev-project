using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGeneratorController
{
    float upgradeMultiplier { get; set; }
    int generatorCount { get; set; }
    string name { get; set; }

}
