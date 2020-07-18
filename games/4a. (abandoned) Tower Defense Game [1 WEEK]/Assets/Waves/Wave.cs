using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public int WaveNumber;
    public int crawlerCount;
    public int demonCount;
    public float spawnRate; // not implemented
}
