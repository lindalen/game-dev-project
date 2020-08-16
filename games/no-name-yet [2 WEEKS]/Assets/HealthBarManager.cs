using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] FloatVariable maxHP;
    [SerializeField] FloatVariable currentHP;
    [SerializeField] Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(currentHP.RuntimeValue / maxHP.RuntimeValue, 1f, 1f);
        healthText.text = currentHP.RuntimeValue + " / " + maxHP.RuntimeValue;
        InvokeRepeating("TestHealthBar", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TestHealthBar()
    {
        currentHP.RuntimeValue -= 6.66f;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float current = currentHP.RuntimeValue;
        float max = maxHP.RuntimeValue;

        // not elegant but it works
        if (current / max < 0)
        {
            healthText.text = 0 + " / " + maxHP.RuntimeValue;
            transform.localScale = new Vector3(0, 1f, 1f);
            return;
        }

        transform.localScale = new Vector3(current / max, 1f, 1f);
        healthText.text = current + " / " + max;
    }

}
