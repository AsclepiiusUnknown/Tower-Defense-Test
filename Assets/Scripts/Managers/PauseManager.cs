using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject shopUI;
    public GameObject optionsMenuUI;

    public string menuScene = "MainMenu";

    public SceneFader sceneFader;

    void Start()
    {
        optionsMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (optionsMenuUI.activeSelf)
            {
                optionsMenuUI.SetActive(false);
                PauseUI.SetActive(true);
            }
            else
            {
                Toggle();
            }
        }
    }

    public void Toggle()
    {
        //shopUI.SetActive(UI.activeSelf); //Optional: Deactivates the shop ui during pauses
        PauseUI.SetActive(!PauseUI.activeSelf);

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
        Toggle();

        string currentScene = SceneManager.GetActiveScene().name;
        sceneFader.FadeTo(currentScene);
    }

    public void ToggleOptions()
    {
        print("options");
        if (optionsMenuUI != null)
        {
            optionsMenuUI.SetActive(!optionsMenuUI.activeSelf);
            PauseUI.SetActive(!PauseUI.activeSelf);
        }
    }

    public void Menu()
    {
        //print("Go to menu");
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuScene);
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
}
