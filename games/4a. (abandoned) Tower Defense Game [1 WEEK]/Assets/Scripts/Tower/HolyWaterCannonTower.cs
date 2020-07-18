using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterCannonTower : MonoBehaviour, ITower
{
    [SerializeField] public TowerConfig Config { get; set; }
    [SerializeField] public float Damage { get; set; }
    [SerializeField] public float FireRate { get; set; }
    [SerializeField] public float Cost { get; set; }
    [SerializeField] public float AttackRadius { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ITower.DealDamage()
    {
        Debug.Log("huh");
    }
    void ITower.DetectEnemiesInRange()
    {
        Debug.Log("huh");
    }
    void ITower.SelectEnemy()
    {
        Debug.Log("huh");
    }
}
