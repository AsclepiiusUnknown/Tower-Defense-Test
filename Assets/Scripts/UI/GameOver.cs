using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI wavesText;

    public string menuScene = "MainMenu";

    public SceneFader sceneFader;

    void OnEnable()
    {
        wavesText.text = PlayerStats.Waves.ToString();
    }

    public void Retry()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        sceneFader.FadeTo(currentScene);
    }

    public void Menu()
    {
        //Debug.Log("Go To Menu.");

        sceneFader.FadeTo(menuScene);
    }
}
