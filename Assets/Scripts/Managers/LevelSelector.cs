using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuScene = "MainMenu";

    public Button[] levelButtons;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneFader.FadeTo(menuScene);
        }
    }

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
