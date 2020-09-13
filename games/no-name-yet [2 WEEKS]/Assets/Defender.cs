using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : MonoBehaviour
{
    [SerializeField] FloatVariable damageReductionPercentage;
    [SerializeField] FloatVariable damageCooldown;
    [SerializeField] FloatVariable defenseDuration;
    [SerializeField] GameObject playerManagerGO;

    [SerializeField] Image healthBar;

    private bool active = false;
    private float lastDefenseTime;
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Awake()
    {
        healthBar.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;
        DefenseLoop();
    }

    private void DefenseLoop()
    {
        if (Time.time < lastDefenseTime + damageCooldown.RuntimeValue + (1 / damageCooldown.RuntimeValue)) return;

        Defend();
    }

    private void Defend()
    {
        ChangeHealthBarColor(Color.grey);

        float finishDefendingTime = Time.time + damageCooldown.RuntimeValue;

        // change player damage reduction
        while (Time.time < finishDefendingTime)
        {
            
        }

        // change player damage reduction to 1

        // color of healthbar to green
    }
    public void SetActive(bool b)
    {
        active = b;
    }

    private void ChangeHealthBarColor(Color c)
    {
        healthBar.color = c;
    }
}
