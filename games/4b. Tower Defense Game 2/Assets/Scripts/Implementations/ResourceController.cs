using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceController : MonoBehaviour
{
    public float money;
    public float health;

    [SerializeField] private float killMoney;
    private static ResourceController _instance;
    public static ResourceController Instance { get { return _instance; } }

    [SerializeField] private GameObject waveManager;
    [SerializeField] private GameObject gameOverPanel;

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
        money = 1000;
        health = 100;
    }

    private void Start()
    {
        waveManager.GetComponent<WaveSpawner>().StartWaveManager();
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
            DisplayGameOverScreen();
        }
    }
    public void DisplayGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }

    public void OnEnemyKill()
    {
        money += killMoney;
        Debug.Log("Money is now: " + money);
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
