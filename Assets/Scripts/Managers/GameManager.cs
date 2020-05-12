using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject shopUI;
    public GameObject SceneFader;

    public static bool gameIsOver;


    void Awake()
    {
        SceneFader.SetActive(true);
    }

    void Start()
    {
        gameIsOver = false;
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

        gameOverUI.SetActive(true);
        shopUI.SetActive(false);
    }
}
