using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableIfCantAfford : MonoBehaviour
{
    [SerializeField] private TowerConfig config;
    private Button button;
    private bool lastState;
    void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = lastState;
    }
    void FixedUpdate()
    {
        if(ResourceController.Instance.money > config.price != lastState)
        {
            lastState = ResourceController.Instance.money >= config.price;
            button.interactable = lastState;
        }
        
    }
}
