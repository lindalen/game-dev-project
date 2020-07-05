using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool gameOver;

    void Awake()
    {
        gameOver = false;
    }
    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        Invoke("LoadMainMenu", 5f);
    }

    public void Victory()
    {
        Invoke("LoadVictoryScreen", 4f);
        
    }

    private void LoadVictoryScreen()
    {
        SceneManager.LoadScene("VictoryScene");
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
