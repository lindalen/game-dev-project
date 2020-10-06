using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHPByLevel : MonoBehaviour
{
    [SerializeField] IntVariable playerLevel;
    [SerializeField] FloatVariable playerMaxHP;
    [SerializeField] float baseHealth; //yeah yeah should be float variable
    [SerializeField] float hpByLevelMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scale()
    {
        playerMaxHP.RuntimeValue = baseHealth * Mathf.Pow(hpByLevelMultiplier, playerLevel.RuntimeValue);
    }
}
