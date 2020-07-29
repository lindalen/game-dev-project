using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatPoisonDartGunUIUpdater : MonoBehaviour
{
    [SerializeField] private TowerConfig config;
    [SerializeField] private Text priceText;
    [SerializeField] private Text attacksPerSecondText;
    [SerializeField] private Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        priceText.text = "Price: " + config.price;
        attacksPerSecondText.text = "APS: " + config.attacksPerSecond + "/s";
        damageText.text = "Damage: " + config.damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
