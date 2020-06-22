using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("UI Elements")]
    public GameObject PauseUI;
    public GameObject OptionsUI;
    public GameObject GameOverUI;
    public GameObject ShopUI;
    public GameObject VictoryUI;

    [Header("Other")]
    public SceneFader sceneFader;
    public static bool gameIsOver;
    public string menuScene = "MainMenu";
    #endregion

    #region Setup
    void Start()
    {
        sceneFader.gameObject.SetActive(true);

        gameIsOver = false;

        PauseUI.SetActive(false);
        OptionsUI.SetActive(false);
        GameOverUI.SetActive(false);
        VictoryUI.SetActive(false);

        ShopUI.SetActive(true);
    }
    #endregion

    #region Debugging
    void Update()
    {
        if (!gameIsOver && PlayerStats.lives <= 0)
        {
            EndGame();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.E))
        {
            EndGame();
        }
#endif
    }
    #endregion

    #region End of Level
    //Used when the player loses the level
    void EndGame()
    {
        gameIsOver = true;
        //Debug.Log("GAME OVER!");

        GameOverUI.SetActive(true);
        ShopUI.SetActive(false);
    }

    //used when the player wins the level
    public void WinLevel()
    {
        Debug.Log("LEVEL WON!!");

        gameIsOver = true;
        VictoryUI.SetActive(true);
    }
    #endregion

    #region UI Manager
    //used to retry the lost level
    public void Retry()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        sceneFader.FadeTo(currentScene);
    }

    //Used to go to the menu scene
    public void Menu()
    {
        //Debug.Log("Go To Menu.");
        TogglePause(true);
        sceneFader.FadeTo(menuScene);
    }

    //used to toggle the pause menu
    public void TogglePause(bool toggleTimeScale)
    {
        if (gameIsOver)
            return;

        if (OptionsUI.activeSelf)
        {
            OptionsUI.SetActive(false);
            PauseUI.SetActive(true);
            return;
        }

        //shopUI.SetActive(UI.activeSelf); //Optional: Deactivates the shop ui during pauses
        PauseUI.SetActive(!PauseUI.activeSelf);

        if (!toggleTimeScale)
            return;

        if (PauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    //used to restart the current level
    public void Restart()
    {
        TogglePause(true);

        string currentScene = SceneManager.GetActiveScene().name;
        sceneFader.FadeTo(currentScene);
    }

    //used to toggle the options menu
    public void ToggleOptions()
    {
        print("Options");
        if (OptionsUI != null)
        {
            OptionsUI.SetActive(true);

            if (!gameIsOver)
                PauseUI.SetActive(!PauseUI.activeSelf);
        }
        else
        {
            Debug.LogError("OptionsUI could not be found by GameManager");
        }
    }

    //used to quit the game
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit
#endif

        //sceneFader.FadeToQuit();
        //print("PM");
    }

    //used to continue to the next level
    public void Continue(string nextLevel, int indexToUnlock)
    {
        PlayerPrefs.SetInt("Level Reached", indexToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    #endregion
}
