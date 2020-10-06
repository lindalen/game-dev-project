using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBarManager : MonoBehaviour
{
    [SerializeField] IntVariable playerLevel;
    [SerializeField] FloatVariable baseLevelExp;
    [SerializeField] FloatVariable levelMultiplier;
    [SerializeField] FloatVariable playerExp;

    BigNumberFormatter formatter;
    ScaleHPByLevel scaler;

    [SerializeField] Text expText;
    [SerializeField] Text levelText;

    float lastLevelExp;
    float nextLevelExp;

    void Awake()
    {
        scaler = GetComponent<ScaleHPByLevel>();
        formatter = GetComponent<BigNumberFormatter>();
        if (playerExp.RuntimeValue<baseLevelExp.RuntimeValue)
        {
            lastLevelExp = 0;
            nextLevelExp = baseLevelExp.RuntimeValue;
            playerLevel.RuntimeValue = 1;
        } else
        {
            SetLevelFromExp();
        }
        UpdateExpBar();
        UpdateExpText();
        UpdateLevelText();
    }

    private void Start()
    {
        UpdateExpBar();
        UpdateExpText();
        UpdateLevelText();
    }

    private void SetLevelFromExp()
    {
        nextLevelExp = baseLevelExp.RuntimeValue; //not completely sure about this
        while (playerExp.RuntimeValue>nextLevelExp)
        {
            LevelUp();
        }
    }

    private void LevelCheck()
    {
        if (playerExp.RuntimeValue >= nextLevelExp)
        {
            LevelUp();

        }
    }
    private void UpdateExpBar()
    {
        transform.localScale = new Vector3((playerExp.RuntimeValue-lastLevelExp) / (nextLevelExp - lastLevelExp), 1f, 1f);
    }

    private void UpdateExpText()
    {
        expText.text = formatter.GetFormattedNumber(playerExp.RuntimeValue) + " / " + formatter.GetFormattedNumber(nextLevelExp);
    }

    private void UpdateLevelText()
    {
        levelText.text = ""+playerLevel.RuntimeValue;
    }

    private void ExpBarReset()
    {

    }
    private void LevelUp()
    {
        lastLevelExp = nextLevelExp;
        nextLevelExp *= levelMultiplier.RuntimeValue;
        playerLevel.RuntimeValue += 1;
        scaler.Scale();
        UpdateLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        LevelCheck();
        UpdateExpText();
        UpdateExpBar();
    }

    private void IncreaseExp()
    {
        playerExp.RuntimeValue += 10000;
    }
}
