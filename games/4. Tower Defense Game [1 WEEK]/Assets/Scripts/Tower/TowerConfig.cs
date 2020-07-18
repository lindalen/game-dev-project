using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
public class TowerConfig : ScriptableObject
{
    public float damage;
    public float firerate;
    public float cost;
}
