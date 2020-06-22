using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    #region Variables
    public GameManager gameManager;
    #endregion

    #region Setup
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError(this + "couldn't find GameManager");
        }
    }
    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameManager.OptionsUI.activeSelf)
            {
                gameManager.OptionsUI.SetActive(false);
                gameManager.PauseUI.SetActive(true);
            }
            else
            {
                TogglePause();
            }
        }
    }

    #region menu Item Fucntionality
    public void TogglePause()
    {
        gameManager.TogglePause(true);
    }

    public void Restart()
    {
        gameManager.Restart();
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
    #endregion
}
