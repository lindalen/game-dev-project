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
    [SerializeField] Text expText;
    [SerializeField] Text levelText;

    float nextLevelExp;

    void Awake()
    {
        formatter = GetComponent<BigNumberFormatter>();
        if (playerExp.RuntimeValue<baseLevelExp.RuntimeValue)
        {
            nextLevelExp = baseLevelExp.RuntimeValue;
            playerLevel.RuntimeValue = 1;
        } else
        {
            SetLevelFromExp();
        }
    }

    private void Start()
    {
        UpdateExpBar();
        UpdateExpText();
        UpdateLevelText();
        Debug.Log("Level is " + playerLevel.RuntimeValue);
    }

    private void SetLevelFromExp()
    {
        nextLevelExp = baseLevelExp.RuntimeValue; //not completely sure about this
        while (playerExp.RuntimeValue>nextLevelExp)
        {
            nextLevelExp *= levelMultiplier.RuntimeValue;
            playerLevel.RuntimeValue+=1;
            Debug.Log("Level is now " + playerLevel.RuntimeValue);
        }
    }

    private void UpdateExpBar()
    {
        transform.localScale = new Vector3(playerExp.RuntimeValue / nextLevelExp, 1f, 1f);
    }

    private void UpdateExpText()
    {
        Debug.Log("Updating text");
        expText.text = formatter.GetFormattedNumber(playerExp.RuntimeValue) + " / " + formatter.GetFormattedNumber(nextLevelExp);
    }

    private void UpdateLevelText()
    {
        levelText.text = ""+playerLevel.RuntimeValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
