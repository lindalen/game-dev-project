using UnityEngine;
using UnityEngine.UI;


public class ShowCostInText : MonoBehaviour
{
    [SerializeField] GameObject GoThatHasUpgradeCost;
    [SerializeField] Text text;
    private FloatVariableUpgradeOnClick upgrader;

    // Start is called before the first frame update
    void Start()
    {
        upgrader = GoThatHasUpgradeCost.GetComponent<FloatVariableUpgradeOnClick>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Cost: " + upgrader.GetCost().ToString("F0") + " $";
    }
}
