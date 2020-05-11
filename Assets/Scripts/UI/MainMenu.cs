using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Lvl1";

    public GameObject optionsMenuUI;

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
            }
        }
    }

    public void Play()
    {
        //print("play");
        SceneManager.LoadScene(levelToLoad);
    }

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

    public void Quit()
    {
        //print("Quitting...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit
#endif
    }
}
