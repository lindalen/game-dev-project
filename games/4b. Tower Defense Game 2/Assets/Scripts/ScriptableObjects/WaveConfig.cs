﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveConfig : ScriptableObject
{
    public int waveNumber;
    public int numberOfEnemies;
    public float enemiesPerSecond;
}