using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUIUpdater : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text moneyText;


    // Update is called once per frame
    void FixedUpdate()
    {
        healthText.text = "" + ResourceController.Instance.health;
        moneyText.text = "" + ResourceController.Instance.money;
    }
}
