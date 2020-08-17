using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] FloatVariable maxHP;
    [SerializeField] FloatVariable currentHP;
    [SerializeField] Text healthText;

    BigNumberFormatter formatter;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(currentHP.RuntimeValue / maxHP.RuntimeValue, 1f, 1f);
        formatter = GetComponent<BigNumberFormatter>();
        UpdateHealthBarText(currentHP.RuntimeValue, maxHP.RuntimeValue);
        InvokeRepeating("TestHealthBar", 0.5f, 0.5f);

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
            // UPDATES BAR TEXT
            UpdateHealthBarText(0, max);
            // UPDATES HEALTH BAR
            transform.localScale = new Vector3(0, 1f, 1f);
            return;
        }
        // UPDATES HEALTH BAR
        transform.localScale = new Vector3(current / max, 1f, 1f);
        // UPDATES BAR TEXT
        UpdateHealthBarText(current, max);
    }

    void UpdateHealthBarText(float current, float max)
    {
        healthText.text = formatter.GetFormattedNumber(current) + " / " + formatter.GetFormattedNumber(max);
    }

}
