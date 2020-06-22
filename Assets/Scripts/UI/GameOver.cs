using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
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

    #region Menu Items
    //used to retry the level
    public void Retry()
    {
        gameManager.Retry();
    }

    //used to toggle the options
    public void ToggleOptions()
    {
        gameManager.ToggleOptions();
    }

    //used to go to the menu
    public void Menu()
    {
        gameManager.Menu();
    }

    //used to quit the game
    public void Quit()
    {
        gameManager.Quit();
    }
    #endregion
}
