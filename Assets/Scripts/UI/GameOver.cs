using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError(this + "couldn't find GameManager");
        }
    }

    public void Retry()
    {
        gameManager.Retry();
    }

    public void ToggleOptions()
    {
        gameManager.ToggleOptions();
    }

    public void Menu()
    {
        gameManager.Menu();
    }

    public void Quit()
    {
        gameManager.Quit();
    }
}
