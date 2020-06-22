using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    #region Variables
    public SceneFader sceneFader;
    public string menuScene = "MainMenu";

    public Button[] levelButtons;
    #endregion

    #region Setup
    void Awake()
    {
        if (!sceneFader.gameObject.activeSelf)
        {
            sceneFader.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("Level Reached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    #endregion

    void Update()
    {
        //if we escape go to the menu scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneFader.FadeTo(menuScene);
        }
    }

    #region Select
    //used to fade to the given level when we select it
    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
    #endregion
}
