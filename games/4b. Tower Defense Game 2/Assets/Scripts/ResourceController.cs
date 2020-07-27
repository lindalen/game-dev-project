using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public float money;
    public float health;

    private static ResourceController _instance;
    public static ResourceController Instance { get { return _instance; } }
    


    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
        money = 0;
        health = 100;
    }

    public bool CanAfford(float cost)
    {
        return cost <= money;
    }

    public void AddMoney(float amount)
    {
        money += amount;
    }

    public void SpendMoney(float amount)
    {
        if (CanAfford(amount))
        {
            money -= amount;
        }
    }

    public void LoseHealth(float amount)
    {
        health -= amount;
        if (IsDead())
        {
            Debug.Log("IMPLEMENT GAMEOVER FUNCTION HERE");
        }
    }

    private bool IsDead()
    {
        return health <= 0;
    }

    public float GetMoney()
    {
        return money;
    }

    public float GetHealth()
    {
        return health;
    }
}
