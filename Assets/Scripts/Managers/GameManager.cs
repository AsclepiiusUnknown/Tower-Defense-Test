using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject PauseUI;
    public GameObject OptionsUI;
    public GameObject GameOverUI;
    public GameObject ShopUI;
    public GameObject VictoryUI;

    [Header("Other")]
    public SceneFader sceneFader;
    public static bool gameIsOver;
    public string menuScene = "TDMenu";

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

    void EndGame()
    {
        gameIsOver = true;
        //Debug.Log("GAME OVER!");

        GameOverUI.SetActive(true);
        ShopUI.SetActive(false);
    }

    public void WinLevel()
    {
        Debug.Log("LEVEL WON!!");

        gameIsOver = true;
        VictoryUI.SetActive(true);
    }

    #region UI Manager

    public void Retry()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        sceneFader.FadeTo(currentScene);
    }

    public void Menu()
    {
        //Debug.Log("Go To Menu.");
        TogglePause(true);
        sceneFader.FadeTo(menuScene);
    }

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

    public void Restart()
    {
        TogglePause(true);

        string currentScene = SceneManager.GetActiveScene().name;
        sceneFader.FadeTo(currentScene);
    }

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

    public void Continue(string nextLevel, int indexToUnlock)
    {
        PlayerPrefs.SetInt("Level Reached", indexToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    #endregion


    /*void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }*/
}
