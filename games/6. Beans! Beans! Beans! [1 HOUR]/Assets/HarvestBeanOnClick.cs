using UnityEngine;

public class HarvestBeanOnClick : MonoBehaviour
{
    [SerializeField] FloatVariable beansPerClick;
    [SerializeField] FloatVariable totalBeans; // a little risky

    public void Harvest()
    {
        totalBeans.RuntimeValue += beansPerClick.RuntimeValue;
    }
}
