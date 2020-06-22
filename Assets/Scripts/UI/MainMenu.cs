using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Variables
    public string levelToLoad = "Lvl1";

    public GameObject optionsMenuUI;

    public SceneFader sceneFader;
    #endregion

    #region Setup
    void Start()
    {
        sceneFader.gameObject.SetActive(true);
        optionsMenuUI.SetActive(false);
    }
    #endregion

    void Update()
    {
        //if were in options menu then go back to the main menu
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (optionsMenuUI.activeSelf)
            {
                optionsMenuUI.SetActive(false);
            }
        }
    }

    #region Menu Functionality
    //used to play the game
    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    //Toggle options on/off
    public void ToggleOptions()
    {
        print("options");
        if (optionsMenuUI != null)
        {
            optionsMenuUI.SetActive(!optionsMenuUI.activeSelf);
        }
        else
        {
            Debug.LogError("MainMenu.cs couldnt find optionsMenuUI.");
        }
    }

    //Quit the game
    public void Quit()
    {
        //print("Quitting...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit
#endif
    }
    #endregion
}
